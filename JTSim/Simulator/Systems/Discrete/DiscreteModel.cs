using JMath;

namespace JTSim
{
    public abstract class DiscreteModel
    {
        public JVector initStates;
        public JVector initInputs;

        public abstract double DifferenceEquation(JVector states, JVector inputs, double t, double h);

        public abstract double OutputEquation(JVector states, JVector inputs);
    }
}
