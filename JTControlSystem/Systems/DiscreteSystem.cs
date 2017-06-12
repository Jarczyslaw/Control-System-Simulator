using JTControlSystem.Models;
using JTMath;
using System;

namespace JTControlSystem.Systems
{
    public class DiscreteSystem : ISystem
    {
        private IDiscreteModel model;

        private Vector initialStates;
        private Vector states;
        private Vector inputs;

        private TransportDelay transportDelay;
        private double delay;

        public DiscreteSystem(IDiscreteModel model, Vector initialStates) : this(model, initialStates, 0d) { }

        public DiscreteSystem(IDiscreteModel model, Vector initialStates, double delay)
        {
            this.model = model;
            this.initialStates = initialStates;
            this.delay = delay;
        }

        public double NextIteration(double input, double time, double dt)
        {
            inputs.Push(input);
            double newOutput = model.DifferenceEquation(states, inputs, time, dt);
            states.Push(newOutput);
            return transportDelay.NextStep(newOutput);
        }

        public double Initialize(double dt)
        {
            if (model.GetOutputOrder != initialStates.Rows)
                throw new Exception("Initialization error. Initial states have different length than model order");

            inputs = Vector.Zeros(model.GetInputOrder);
            states = initialStates.Clone();
            double initialOutput = model.OutputEquation(states, inputs);
            transportDelay = new TransportDelay(delay, initialOutput, dt);
            return initialOutput;
        }
    }
}
