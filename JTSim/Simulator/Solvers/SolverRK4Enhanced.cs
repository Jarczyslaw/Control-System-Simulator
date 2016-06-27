using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;

namespace JTSim
{
    public class SolverRK4Enhanced : ISolver
    {
        private double oneThirdStep;
        private double oneEightStep;

        public Vector<double> Solve(ContinousModel model, Vector<double> state, double input, double t, double h)
        {
            
            Vector<double> k1 = model.DifferentialEquasions(state, input, t);
            Vector<double> k2 = model.DifferentialEquasions(state + oneThirdStep * k1, input, t + oneThirdStep);
            Vector<double> k3 = model.DifferentialEquasions(state + (-oneThirdStep * k1 + h * k2), input, t + 2d * oneThirdStep);
            Vector<double> k4 = model.DifferentialEquasions(state + h * (k1 - k2 + k3), input, t + h);
            return state + oneEightStep * (k1 + 3f * k2 + 3f * k3 + k4);
        }

        public void Init(double h)
        {
            oneEightStep = h / 8d;
            oneThirdStep = h / 3d;
        }
    }
}
