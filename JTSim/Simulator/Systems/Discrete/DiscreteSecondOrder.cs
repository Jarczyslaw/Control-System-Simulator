using MathNet.Numerics.LinearAlgebra;

namespace JTSim
{
    public class DiscreteSecondOrder : DiscreteModel
    {
        double k = 2d;
        double T1 = 1d;
        double T2 = 1d;

        public DiscreteSecondOrder(double y_1, double y_2)
        {
            initStates = Vector<double>.Build.Dense(new double[] { y_1, y_2 });
            initInputs = Vector<double>.Build.Dense(1, 0d);
        }

        public DiscreteSecondOrder(double y_1, double y_2, double k, double T1, double T2) : this(y_1, y_2)
        {
            this.k = k;
            this.T1 = T1;
            this.T2 = T2;
        }

        public override double DifferenceEquasion(Vector<double> states, Vector<double> inputs, double t, double h)
        {
            double A = h * h + h * (T1 + T2) + T1 * T2;
            double B = -2d * T1 * T2 - h * (T1 + T2);
            double C = T1 * T2;
            double D = k * h * h;

            return -B/A * states[0] - C/A * states[1] + D/A * inputs[0];
        }

        public override double OutputEquation(Vector<double> states, Vector<double> inputs)
        {
            return states[0];
        }
    }
}
