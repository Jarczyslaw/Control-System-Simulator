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
        public Vector<float> Solve(ContinousModel model, Vector<float> state, float input, float t, float h)
        {
            float third = 1f / 3f;
            Vector<float> k1 = h * model.DifferentialEquasions(state, input, t);
            Vector<float> k2 = h * model.DifferentialEquasions(state + third * k1, input, t + third * h);
            Vector<float> k3 = h * model.DifferentialEquasions(state + (-third * k1 + k2), input, t + 2f * third * h);
            Vector<float> k4 = h * model.DifferentialEquasions(state + (k1 - k2 + k3), input, t + h);
            return state + 1f / 8f * (k1 + 3f * k2 + 3f * k3 + k4);
        }
    }
}
