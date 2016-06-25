using MathNet.Numerics.LinearAlgebra;

namespace JTSim
{
    public class SolverRK4 : ISolver
    {
        public Vector<float> Solve(ContinousModel model, Vector<float> state, float input, float t, float h)
        {
            Vector<float> k1 = h * model.DifferentialEquasions(state, input, t);
            Vector<float> k2 = h * model.DifferentialEquasions(state + 0.5f * k1, input, t + 0.5f * h);
            Vector<float> k3 = h * model.DifferentialEquasions(state + 0.5f * k2, input, t + 0.5f * h);
            Vector<float> k4 = h * model.DifferentialEquasions(state + k3, input, t + h);

            return state + 1.0f / 6.0f * (k1 + 2 * k2 + 2 * k3 + k4);
        }
    }
}
