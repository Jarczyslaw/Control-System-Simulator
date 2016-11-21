using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JVectors;

namespace JTSim
{
    public class SolverRK4Enhanced : ISolver
    {
        private double oneThirdStep;
        private double oneEightStep;

        public JVector Solve(ContinousModel model, JVector state, double input, double t, double h)
        {

            JVector k1 = model.DifferentialEquations(state, input, t);
            JVector k2 = model.DifferentialEquations(state + oneThirdStep * k1, input, t + oneThirdStep);
            JVector k3 = model.DifferentialEquations(state + (-oneThirdStep * k1 + h * k2), input, t + 2d * oneThirdStep);
            JVector k4 = model.DifferentialEquations(state + h * (k1 - k2 + k3), input, t + h);
            return state + oneEightStep * (k1 + 3f * k2 + 3f * k3 + k4);
        }

        public void Init(double h)
        {
            oneEightStep = h / 8d;
            oneThirdStep = h / 3d;
        }
    }
}
