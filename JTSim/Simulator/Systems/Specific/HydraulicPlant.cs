using MathNet.Numerics.LinearAlgebra;

namespace JTSim
{
    public class HydraulicPlant : ContinousModel
    {
        public float k = 1f;
        public float T = 1.0f;

        public float max = 5f;

        public HydraulicPlant(float initState)
        {
            this.initState = Vector<float>.Build.Dense(1, initState);
        }

        public override Vector<float> DifferentialEquasions(Vector<float> state, float input, float t)
        {
            Vector<float> diff = -1.0f / T * state + k / T * input;
            return diff;
        }

        public override float OutputEquation(Vector<float> state, float input)
        {
            if (state[0] < 0f)
                state[0] = 0f;
            else if (state[0] > max)
                state[0] = max;
            return state[0];
        }
    }
}
