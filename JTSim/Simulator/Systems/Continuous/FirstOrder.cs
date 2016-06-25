using MathNet.Numerics.LinearAlgebra;

namespace JTSim
{
    public class FirstOrder : ContinousModel
    {
        public double k = 1.0d;
        public double T = 1.0d;

        public FirstOrder (double initState) 
        {
            this.initState = Vector<double>.Build.Dense(1, initState);
        }

        public FirstOrder(double initState, double k, double T) : this(initState)
        {
            this.k = k;
            this.T = T;
        }

        public override Vector<double> DifferentialEquasions(Vector<double> state, double input, double t)
        {
            Vector<double> diff = -1.0d / T * state + k / T * input;
            return diff;
        }

        public override double OutputEquation(Vector<double> state, double input)
        {
            return state[0];
        }
    }
}
