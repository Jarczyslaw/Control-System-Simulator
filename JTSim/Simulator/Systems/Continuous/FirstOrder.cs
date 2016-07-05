using JVectors;

namespace JTSim
{
    public class FirstOrder : ContinousModel
    {
        public double k = 1.0d;
        public double T = 1.0d;

        public FirstOrder (double initState) 
        {
            this.initState = new JVector(1, initState);
        }

        public FirstOrder(double initState, double k, double T) : this(initState)
        {
            this.k = k;
            this.T = T;
        }

        public override JVector DifferentialEquasions(JVector state, double input, double t)
        {
            JVector diff = -1.0d / T * state + k / T * input;
            return diff;
        }

        public override double OutputEquation(JVector state, double input)
        {
            return state[0];
        }
    }
}
