using JMath;

namespace JTSim
{
    public class SolverEuler : ISolver
    {
        public JVector Solve(ContinousModel model, JVector state, double input, double t, double h)
        {
            JVector diffs = model.DifferentialEquations(state, input, t);
            return state + h * diffs;
        }

        public void Init(double h) { }
    }
}
