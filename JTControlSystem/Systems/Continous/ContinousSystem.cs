using JTControlSystem.Solvers;
using JTMath;
using System;

namespace JTControlSystem.Systems
{
    public class ContinousSystem : ISystem
    {
        private IContinousModel model;
        private ISolver solver;

        private TransportDelay transportDelay;
        private double delay;

        private Vector initialState;
        private Vector state;

        public ContinousSystem(IContinousModel model, ISolver solver, Vector initialState) : this(model, solver, initialState, 0d) { }

        public ContinousSystem(IContinousModel model, ISolver solver, Vector initialState, double delay)
        {
            this.model = model;
            this.solver = solver;
            this.initialState = initialState;
            this.delay = delay;
        }

        public double NextIteration(double input, double time, double dt)
        {
            state = solver.Solve(model.DifferentialEquations, state, input, time, dt);
            double output = model.OutputEquation(state, input);
            return transportDelay.NextStep(output);
        }

        public double Initialize(double dt)
        {
            if (initialState.Count() != model.GetOrder)
                throw new Exception("Initialization error. Initial state has different length than model's order");

            solver.Initialize(dt);
            state = initialState.Clone();
            double initialOutput = model.OutputEquation(state, 0d);
            transportDelay = new TransportDelay(delay, initialOutput, dt);
            return initialOutput;
        }
    }
}
