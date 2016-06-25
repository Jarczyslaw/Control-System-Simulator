using MathNet.Numerics.LinearAlgebra;

namespace JTSim
{
    public class SolverRK4 : ISolver
    {
        public Vector<double> Solve(ContinousModel model, Vector<double> state, double input, double t, double h)
        {
            Vector<double> k1 = h * model.DifferentialEquasions(state, input, t);
            Vector<double> k2 = h * model.DifferentialEquasions(state + 0.5d * k1, input, t + 0.5d * h);
            Vector<double> k3 = h * model.DifferentialEquasions(state + 0.5d * k2, input, t + 0.5d * h);
            Vector<double> k4 = h * model.DifferentialEquasions(state + k3, input, t + h);
            Vector<double> diff = 1.0d / 6.0d * (k1 + 2d * k2 + 2d * k3 + k4);
            return state + diff;
        }
    }
}
