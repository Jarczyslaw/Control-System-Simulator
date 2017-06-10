using JTMath;

namespace JTControlSystem.Solvers
{
    public class SolverAdamsBashforth : ISolver
    {
        private JQueue<Vector> diffs;
        private ISolver starter = new SolverRK4();
        private double[] coeffs;
        private int order;

        public SolverAdamsBashforth(int order)
        {
            this.order = order;
            diffs = new JQueue<Vector>(order);
            if (order == 1)
                coeffs = new double[1] { 1d }; // euler
            else if (order == 2)
                coeffs = new double[2] { 3d / 2d, -1d / 2d };
            else if (order == 3)
                coeffs = new double[3] { 23d / 12d, -4d / 3d, 5d / 12d };
            else if (order == 4)
                coeffs = new double[4] { 55d / 24d, -59d / 24d, 37d / 24d, -3d / 8d };
            else
                coeffs = new double[5] { 1901d / 720d, -1387d / 360d, 109d / 30d, -637d / 360d, 251d / 720d };
        }

        public Vector Solve(DifferentialEquations differentialEquasions, Vector state, double input, double time, double dt)
        {
            diffs.Push(differentialEquasions(state, input, time));
            if (diffs.Count() < order)
                return starter.Solve(differentialEquasions, state, input, time, dt);
            else
            {
                Vector sum = new Vector(state.Count(), 0d);
                for (int i = 0; i < order; i++)
                    sum += coeffs[i] * diffs[i];
                Vector ds = dt * sum;
                return state + ds;
            }
        }

        public void Initialize(double dt)
        {
            starter.Initialize(dt);
            diffs.Clear();
        }
    }
}
