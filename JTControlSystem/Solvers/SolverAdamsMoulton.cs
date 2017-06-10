using System;
using JTControlSystem;
using JTControlSystem.Solvers;
using JTMath;

namespace JTControlSystem.Solvers
{
    public class SolverAdamsMoulton : ISolver
    {
        private JQueue<Vector> diffs;
        private ISolver starter = new SolverRK4();
        private double[] coeffs;
        private int order;

        public SolverAdamsMoulton(int order)
        {
            this.order = order;
            diffs = new JQueue<Vector>(order - 1);
            if (order == 3)
                coeffs = new double[3] { 5d / 12d, 2d / 3d, -1d / 12d };
            else if (order == 4)
                coeffs = new double[4] { 3d / 8d, 19d / 24d, -5d / 24d, 1d / 24d };
            else
                coeffs = new double[5] { 251d / 720d, 646d / 720d, -264d / 720d, 106d / 720d, -19d / 720d };
        }

        public Vector Solve(DifferentialEquations differentialEquasions, Vector state, double input, double time, double dt)
        {
            diffs.Push(differentialEquasions(state, input, time));
            if (diffs.Count() < order - 1)
                return starter.Solve(differentialEquasions, state, input, time, dt);
            else
            {
                Vector prediction = starter.Solve(differentialEquasions, state, input, time, dt);
                Vector sum = new Vector(state.Rows, 0d);
                sum += coeffs[0] * differentialEquasions(prediction, input, time + dt);
                for (int i = 0; i < order - 1; i++)
                    sum += coeffs[i + 1] * diffs[i];
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
