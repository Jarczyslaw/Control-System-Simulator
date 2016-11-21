using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JVectors;

namespace JTSim
{
    public class SolverEulerTrapezoidal : ISolver
    {
        private double halfStep;

        public void Init(double h)
        {
            halfStep = 0.5 * h;
        }

        public JVector Solve(ContinousModel model, JVector state, double input, double t, double h)
        {
            JVector diffs = model.DifferentialEquations(state, input, t);
            JVector prediction = state + h * diffs;
            return state + halfStep * (diffs + model.DifferentialEquations(prediction, input, t + h)); // trapezoidal rule
        }
    }
}
