using JMath;

namespace JTSim
{
    public abstract class ContinousModel
    {
        public JVector initState;

        public abstract JVector DifferentialEquations(JVector state, double input, double t);

        public abstract double OutputEquation(JVector state, double input);
    }
}
