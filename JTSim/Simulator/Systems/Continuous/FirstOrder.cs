using MathNet.Numerics.LinearAlgebra;

namespace JTSim
{
    public class FirstOrder : ContinousModel
    {
        public float k = 2.0f;
        public float T = 1.0f;

        public FirstOrder (float initState) 
        {
            this.initState = Vector<float>.Build.Dense(1, initState);
        }

        public FirstOrder(float initState, float k, float T) : this(initState)
        {
            this.k = k;
            this.T = T;
        }

        public override Vector<float> DifferentialEquasions(Vector<float> state, float input, float t)
        {
            Vector<float> diff = -1.0f / T * state + k / T * input;
            return diff;
        }

        public override float OutputEquation(Vector<float> state, float input)
        {
            return state[0];
        }
    }
}
