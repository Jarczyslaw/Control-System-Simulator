using MathNet.Numerics.LinearAlgebra;

namespace JTSim
{
    public class DiscreteSecondOrder : DiscreteModel
    {
        float k = 2f;
        float T1 = 1f;
        float T2 = 1f;

        public DiscreteSecondOrder(float y_1, float y_2)
        {
            initStates = Vector<float>.Build.Dense(new float[] { y_1, y_2 });
            initInputs = Vector<float>.Build.Dense(1, 0f);
        }

        public DiscreteSecondOrder(float y_1, float y_2, float k, float T1, float T2) : this(y_1, y_2)
        {
            this.k = k;
            this.T1 = T1;
            this.T2 = T2;
        }

        public override float DifferenceEquasion(Vector<float> states, Vector<float> inputs, float t, float h)
        {
            float A = h * h + h * (T1 + T2) + T1 * T2;
            float B = -2f * T1 * T2 - h * (T1 + T2);
            float C = T1 * T2;
            float D = k * h * h;

            return -B/A * states[0] - C/A * states[1] + D/A * inputs[0];
        }

        public override float OutputEquation(Vector<float> states, Vector<float> inputs)
        {
            return states[0];
        }
    }
}
