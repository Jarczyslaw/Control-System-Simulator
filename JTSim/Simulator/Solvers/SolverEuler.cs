using JVectors;

namespace JTSim
{
    public class SolverEuler : ISolver
    {
        public JVector Solve(ContinousModel model, JVector state, double input, double t, double h)
        {
            JVector diffs = model.DifferentialEquasions(state, input, t);
            return state + h * diffs;
        }

        public void Init(double h) { }
    }
}
