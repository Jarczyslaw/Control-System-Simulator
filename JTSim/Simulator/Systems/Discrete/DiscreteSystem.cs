using MathNet.Numerics.LinearAlgebra;

namespace JTSim
{
    public class DiscreteSystem : GenericSystem
    {
        public DiscreteModel model;
        public Vector<double> states;
        public Vector<double> inputs;
        private TransportDelay transportDelay;
        private double delay;

        public DiscreteSystem(DiscreteModel model) : this(model, 0d) { }

        public DiscreteSystem (DiscreteModel model, double delay)
        {
            this.model = model;
            this.delay = delay;
        }

        public override void Step(double u, double t, double h)
        {
            PushToVectorF(inputs, u);
            PushToVectorF(states, model.DifferenceEquasion(states, inputs, t, h));
            output = model.OutputEquation(states, inputs);

            output = transportDelay.Step(output);
        }

        public override void Init(double h)
        {
            states = model.initStates.Clone();
            inputs = model.initInputs.Clone();
            double initOutput = model.OutputEquation(states, inputs);
            transportDelay = new TransportDelay(delay, initOutput, h);
            output = initOutput;
        }

        private void PushToVectorF (Vector<double> vect, double newVal)
        {
            for (int i = vect.Count - 2; i >= 0; i--)
                vect[i + 1] = vect[i];
            vect[0] = newVal;
        }
    }
}
