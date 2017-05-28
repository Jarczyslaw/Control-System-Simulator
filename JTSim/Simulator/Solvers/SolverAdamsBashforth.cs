using JMath;
using JTSim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTSim
{
    public class SolverAdamsBashforth : ISolver
    {
        JQueue<JVector> diffs;
        SolverRK4 rk4 = new SolverRK4();
        private double[] coeffs;
        private int order;

        public SolverAdamsBashforth(int order)
        {
            this.order = order;
            diffs = new JQueue<JVector>(order);
            if (order == 1)
                coeffs = new double[1] { 1.0 }; // euler
            else if (order == 2)
                coeffs = new double[2] { 3.0 / 2.0, -1.0 / 2.0 };
            else if (order == 3)
                coeffs = new double[3] { 23.0 / 12.0, -4.0 / 3.0, 5.0 / 12.0 };
            else if (order == 4)
                coeffs = new double[4] { 55.0 / 24.0, -59.0 / 24.0, 37.0 / 24.0, -3.0 / 8.0 };
            else
                coeffs = new double[5] { 1901.0/720.0, -1387.0/360.0, 109.0/30.0, -637.0/360.0, 251.0/720.0 };
        }

        public void Init(double h)
        {
            rk4.Init(h);
            diffs.Clear();
        }

        public JVector Solve(ContinousModel model, JVector state, double input, double t, double h)
        {
            diffs.Push(model.DifferentialEquations(state, input, t));
            if (diffs.Count() < order)
                return rk4.Solve(model, state, input, t, h);
            else
            {
                JVector sum = new JVector(state.Count(), 0.0);
                for (int i = 0; i < order; i++)
                    sum += coeffs[i] * diffs[i];
                JVector ds = h * sum;
                return state + ds;
            }
        }
    }
}
