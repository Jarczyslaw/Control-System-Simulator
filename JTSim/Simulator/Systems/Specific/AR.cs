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

        public AR (double y_1, double y_2, double y_3)
        {
            initStates = Vector<double>.Build.Dense(new double[] { y_1, y_2, y_3 });
            initInputs = Vector<double>.Build.Dense(3, 0d);
        }

        public override double DifferenceEquasion(Vector<double> states, Vector<double> inputs, double t, double h)
        {
            return 0.5d * states[0] + 0.2d * states[1] + 0.2d * states[2] + 0.5d * inputs[1] + 1d * inputs[2];
        }

        public override double OutputEquation(Vector<double> states, Vector<double> inputs)
        {
            return states[0];
        }
    }
}
