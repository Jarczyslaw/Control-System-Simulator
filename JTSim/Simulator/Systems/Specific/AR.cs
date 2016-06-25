using MathNet.Numerics.LinearAlgebra;

namespace JTSim
{
    public class AR : DiscreteModel
    {
        /*
        model AR:
        transmitacja: K(z) = (0.5z + 1)/(z^3 -0.5z^2 - 0.2z - 0.2)
        równanie różnicowe: y(i) = 0.5y(i-1) + 0.2y(i-2) + 0.2y(i-3) + 0.5u(i-2) + u(i-3)
        */

        public AR (float y_1, float y_2, float y_3)
        {
            initStates = Vector<float>.Build.Dense(new float[] { y_1, y_2, y_3 });
            initInputs = Vector<float>.Build.Dense(3, 0f);
        }

        public override float DifferenceEquasion(Vector<float> states, Vector<float> inputs, float t, float h)
        {
            return 0.5f * states[0] + 0.2f * states[1] + 0.2f * states[2] + 0.5f * inputs[1] + 1f * inputs[2];
        }

        public override float OutputEquation(Vector<float> states, Vector<float> inputs)
        {
            return states[0];
        }
    }
}
