using MathNet.Numerics.LinearAlgebra;

namespace JTSim
{
    public class SecondOrder : ContinousModel
    {
        public float k = 2.0f;
        public float T1 = 1.0f;
        public float T2 = 1.0f;

        public SecondOrder(float initState, float initSpeed)
        {
            this.initState = Vector<float>.Build.Dense(new float[] { initState, initSpeed });
        }

        public SecondOrder(float initState, float initSpeed, float k, float T1, float T2) : this(initState, initSpeed)
        {
            this.k = k;
            this.T1 = T1;
            this.T2 = T2;
        }

        public override Vector<float> DifferentialEquasions(Vector<float> state, float input, float t)
        {
            float d = T1 * T2;
            float first = state[1];
            float second = -(T1 + T2) / d * state[1] - 1 / d * state[0] + k / d * input;
            Vector<float> diff = Vector<float>.Build.Dense(new float[] { first, second });
            return diff;
        }

        public override float OutputEquation(Vector<float> state, float u)
        {
            return state[0];
        }
    }
}
