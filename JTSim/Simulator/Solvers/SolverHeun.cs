using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JVectors;

namespace JTSim
{
    public class SolverHeun : ISolver
    {
        private double halfStep;

        public void Init(double h)
        {
            halfStep = 0.5 * h;
        }

        public JVector Solve(ContinousModel model, JVector state, double input, double t, double h)
        {
            JVector k1 = model.DifferentialEquasions(state, input, t);
            JVector k2 = model.DifferentialEquasions(state + h * k1, input, t + h);
            return state + halfStep * (k1 + k2);
        }
    }
}
