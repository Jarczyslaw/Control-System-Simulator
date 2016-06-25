using MathNet.Numerics.LinearAlgebra;

namespace JTSim
{
    public class HydraulicPlant : ContinousModel
    {
        public double k = 1d;
        public double T = 1.0d;

        public double max = 5d;

        public HydraulicPlant(double initState)
        {
            this.initState = Vector<double>.Build.Dense(1, initState);
        }

        public override Vector<double> DifferentialEquasions(Vector<double> state, double input, double t)
        {
            Vector<double> diff = -1.0d / T * state + k / T * input;
            return diff;
        }

        public override double OutputEquation(Vector<double> state, double input)
        {
            if (state[0] < 0d)
                state[0] = 0d;
            else if (state[0] > max)
                state[0] = max;
            return state[0];
        }
    }
}
