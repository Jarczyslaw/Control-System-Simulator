using JMath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTSim
{
    public class SolverMidPoint : ISolver
    {
        private double halfStep;

        public JVector Solve(ContinousModel model, JVector state, double input, double t, double h)
        {
            JVector k1 = model.DifferentialEquations(state, input, t);
            JVector k2 = model.DifferentialEquations(state + halfStep * k1, input, t + halfStep);
            return state + h * k2;
        }

        public void Init(double h)
        {
            halfStep = 0.5d * h;
        }
    }
}
