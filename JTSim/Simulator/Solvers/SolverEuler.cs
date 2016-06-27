using MathNet.Numerics.LinearAlgebra;

namespace JTSim
{
    public class SolverEuler : ISolver
    {
        public Vector<double> Solve(ContinousModel model, Vector<double> state, double input, double t, double h)
        {
            Vector<double> diffs = model.DifferentialEquasions(state, input, t);
            return state + h * diffs;
        }

        public void Init(double h) { }
    }
}
