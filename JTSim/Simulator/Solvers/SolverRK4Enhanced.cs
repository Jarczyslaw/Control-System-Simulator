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
        public Vector<double> Solve(ContinousModel model, Vector<double> state, double input, double t, double h)
        {
            double third = 1d / 3d;
            Vector<double> k1 = h * model.DifferentialEquasions(state, input, t);
            Vector<double> k2 = h * model.DifferentialEquasions(state + third * k1, input, t + third * h);
            Vector<double> k3 = h * model.DifferentialEquasions(state + (-third * k1 + k2), input, t + 2d * third * h);
            Vector<double> k4 = h * model.DifferentialEquasions(state + (k1 - k2 + k3), input, t + h);
            return state + 1d / 8d * (k1 + 3f * k2 + 3f * k3 + k4);
        }
    }
}
