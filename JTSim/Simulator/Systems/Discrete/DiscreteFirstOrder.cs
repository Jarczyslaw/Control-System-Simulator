using MathNet.Numerics.LinearAlgebra;

namespace JTSim
{
    public class DiscreteFirstOrder : DiscreteModel
    {
        public float k = 2.0f;
        public float T = 1.0f;

        public DiscreteFirstOrder(float initState)
        {
            this.initStates = Vector<float>.Build.Dense(1, initState);
            this.initInputs = Vector<float>.Build.Dense(1, 0f);
        }

        public DiscreteFirstOrder(float initState, float k, float T) : this(initState)
        {
            this.k = k;
            this.T = T;
        }

        public override float DifferenceEquasion(Vector<float> states, Vector<float> inputs, float t, float h)
        {
            return (1f - h / T) * states[0] + k * h / T * inputs[0];
        }

        public override float OutputEquation(Vector<float> states, Vector<float> inputs)
        {
            return states[0];
        }
    }
}
