using JTMath;

namespace JTControlSystem.Models
{
    /*
    AutoRegressive discrete model:
    y(i) = B(z^-1) / A(z^-1) * u(i)
    Transferfunction: K(z) = (0.5z + 1)/(z^3 -0.5z^2 - 0.2z - 0.2)
    Difference equation: y(i) = 0.5y(i-1) + 0.2y(i-2) + 0.2y(i-3) + 0.5u(i-2) + u(i-3)
    */

    public class AutoRegressive : IDiscreteModel
    {
        private Vector B = new Vector(new double[] { 0.5d, 1d });
        private Vector A = new Vector(new double[] { 1d, -0.5d, -0.2d, -0.2d });

        public AutoRegressive()
        {
        }

        public AutoRegressive(Vector nominator, Vector denominator)
        {
            B = nominator;
            A = denominator;
        }

        public int GetInputOrder
        {
            get
            {
                return A.Rows - B.Rows + 1;
            }
        }

        public int GetOutputOrder
        {
            get
            {
                return A.Rows - 1;
            }
        }

        public double DifferenceEquation(Vector states, Vector inputs, double time, double dt)
        {
            double output = 0d;
            for (int i = 1; i < A.Rows; i++)
                output += -A[i] * states[i - 1];

            int j = inputs.Rows - B.Rows;
            for (int i = 0; i < B.Rows; i++)
            {
                output += B[i] * inputs[j];
                j++;
            }
            return output;
        }

        public double OutputEquation(Vector states, Vector inputs)
        {
            return states[0];
        }
    }
}