using MathNet.Numerics.LinearAlgebra;

namespace JTSim
{
    public class SolverEuler : ISolver
    {
        public Vector<float> Solve(ContinousModel model, Vector<float> state, float input, float t, float h)
        {
            Vector<float> diffs = model.DifferentialEquasions(state, input, t);
            return state + h * diffs;
        }
    }
}
