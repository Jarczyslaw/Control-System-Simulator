using JVectors;

namespace JTSim
{
    public class DiscreteSystem : GenericSystem
    {
        public DiscreteModel model;
        public JVector states;
        public JVector inputs;
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
            inputs.Push(u);
            states.Push(model.DifferenceEquation(states, inputs, t, h));
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
    }
}
