using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;

namespace JTSim
{
    public class SolverMidPoint : ISolver
    {
        public Vector<double> Solve(ContinousModel model, Vector<double> state, double input, double t, double h)
        {
            Vector<double> k1 = h * model.DifferentialEquasions(state, input, t);
            Vector<double> k2 = h * model.DifferentialEquasions(state + k1 / 2d, input, t + h / 2d);
            return state + 0.5d * (k1 + k2);
        }
    }
}
