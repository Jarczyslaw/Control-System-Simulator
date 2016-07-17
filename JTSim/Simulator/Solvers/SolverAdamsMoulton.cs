using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JVectors;

namespace JTSim
{
    public class SolverAdamsMoulton : ISolver
    {
        JQueue<JVector> diffs;
        SolverRK4 starter = new SolverRK4();
        private double[] coeffs;
        private int order;

        public SolverAdamsMoulton(int order)
        {
            this.order = order;
            diffs = new JQueue<JVector>(order - 1);
            if (order == 3)
                coeffs = new double[3] { 5.0 / 12.0, 2.0 / 3.0, -1.0 / 12.0 };
            else if (order == 4)
                coeffs = new double[4] { 3.0 / 8.0, 19.0 / 24.0, -5.0 / 24.0, 1.0 / 24.0 };
            else
                coeffs = new double[5] { 251.0 / 720.0, 646.0 / 720.0, -264.0 / 720.0, 106.0 / 720.0, -19.0 / 720.0 };
        }

        public void Init(double h)
        {
            starter.Init(h);
            diffs.Clear();
        }

        public JVector Solve(ContinousModel model, JVector state, double input, double t, double h)
        {
            diffs.Push(model.DifferentialEquasions(state, input, t));
            if (diffs.Count() < order - 1)
                return starter.Solve(model, state, input, t, h);
            else
            {
                JVector prediction = starter.Solve(model, state, input, t, h);
                JVector sum = new JVector(state.Count(), 0.0);
                sum += coeffs[0] * model.DifferentialEquasions(prediction, input, t + h);
                for (int i = 0; i < order - 1; i++)
                    sum += coeffs[i + 1] * diffs[i];
                JVector ds = h * sum;
                return state + ds;
            }
        }

    }
}
