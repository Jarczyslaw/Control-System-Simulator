using JVectors;

namespace JTSim
{
    public abstract class ContinousModel
    {
        public JVector initState;

        public abstract JVector DifferentialEquasions(JVector state, double input, double t);

        public abstract double OutputEquation(JVector state, double input);
    }
}
