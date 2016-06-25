using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorF = MathNet.Numerics.LinearAlgebra.Vector<float>;

namespace JTSim
{
    public class DiscreteSystem : GenericSystem
    {
        public DiscreteModel model;
        public VectorF states;
        public VectorF inputs;
        private TransportDelay transportDelay;
        private float delay;

        public DiscreteSystem(DiscreteModel model) : this(model, 0f) { }

        public DiscreteSystem (DiscreteModel model, float delay)
        {
            this.model = model;
            this.delay = delay;
        }

        public override void Step(float u, float t)
        {
            PushToVectorF(inputs, u);
            PushToVectorF(states, model.DifferenceEquasion(states, inputs, t, h));
            output = model.OutputEquation(states, inputs);

            output = transportDelay.Step(output);
        }

        public override void Init()
        {
            states = model.initStates.Clone();
            inputs = model.initInputs.Clone();
            float initOutput = model.OutputEquation(states, inputs);
            transportDelay = new TransportDelay(delay, initOutput, h);
            output = initOutput;
        }

        private void PushToVectorF (VectorF vect, float newVal)
        {
            for (int i = vect.Count - 2; i >= 0; i--)
                vect[i + 1] = vect[i];
            vect[0] = newVal;
        }
    }
}
