using JVectors;

namespace JTSim
{
    public abstract class DiscreteModel
    {
        public JVector initStates;
        public JVector initInputs;

        public abstract double DifferenceEquasion(JVector states, JVector inputs, double t, double h);

        public abstract double OutputEquation(JVector states, JVector inputs);
    }
}
