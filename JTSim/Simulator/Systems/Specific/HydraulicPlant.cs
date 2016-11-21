using JVectors;

namespace JTSim
{
    public class HydraulicPlant : ContinousModel
    {
        public double k = 1d;
        public double T = 1.0d;

        public double max = 5d;

        public HydraulicPlant(double initState)
        {
            this.initState = new JVector(1, initState);
        }

        public override JVector DifferentialEquations(JVector state, double input, double t)
        {
            JVector diff = -1.0d / T * state + k / T * input;
            return diff;
        }

        public override double OutputEquation(JVector state, double input)
        {
            if (state[0] < 0d)
                state[0] = 0d;
            else if (state[0] > max)
                state[0] = max;
            return state[0];
        }
    }
}
