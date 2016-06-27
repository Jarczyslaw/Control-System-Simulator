using MathNet.Numerics.LinearAlgebra;

namespace JTSim
{
    public class SolverRK4 : ISolver
    {
        private double q;
        private double halfStep;

        public Vector<double> Solve(ContinousModel model, Vector<double> state, double input, double t, double h)
        {
            Vector<double> k1 = model.DifferentialEquasions(state, input, t);
            Vector<double> k2 = model.DifferentialEquasions(state + halfStep * k1, input, t + halfStep);
            Vector<double> k3 = model.DifferentialEquasions(state + halfStep * k2, input, t + halfStep);
            Vector<double> k4 = model.DifferentialEquasions(state + h * k3, input, t + h);
            Vector<double> diff = q * (k1 + 2d * k2 + 2d * k3 + k4);
            return state + diff;
        }

        public void Init(double h)
        {
            q = 1.0d / 6.0d * h;
            halfStep = 0.5d * h;
        }
    }
}
