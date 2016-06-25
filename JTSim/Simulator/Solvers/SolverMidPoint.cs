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
        public Vector<float> Solve(ContinousModel model, Vector<float> state, float input, float t, float h)
        {
            Vector<float> k1 = h * model.DifferentialEquasions(state, input, t);
            Vector<float> k2 = h * model.DifferentialEquasions(state + 0.5f * k1, input, t + 0.5f * h);
            return state + 0.5f * (k1 + k2);
        }
    }
}
