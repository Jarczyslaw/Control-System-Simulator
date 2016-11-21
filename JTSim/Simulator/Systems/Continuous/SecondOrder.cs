using JVectors;

namespace JTSim
{
    public class SecondOrder : ContinousModel
    {
        public double k = 1.0d;
        public double T1 = 1.0d;
        public double T2 = 1.0d;

        public SecondOrder(double initState, double initSpeed)
        {
            this.initState = new JVector(new double[] { initState, initSpeed });
        }

        public SecondOrder(double initState, double initSpeed, double k, double T1, double T2) : this(initState, initSpeed)
        {
            this.k = k;
            this.T1 = T1;
            this.T2 = T2;
        }

        public override JVector DifferentialEquations(JVector state, double input, double t)
        {
            double d = T1 * T2;
            double first = state[1];
            double second = -(T1 + T2) / d * state[1] - 1d / d * state[0] + k / d * input;
            JVector diff = new JVector(new double[] { first, second });
            return diff;
        }

        public override double OutputEquation(JVector state, double u)
        {
            return state[0];
        }
    }
}
