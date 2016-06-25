using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorF = MathNet.Numerics.LinearAlgebra.Vector<float>;

namespace JTSim
{
    public class SolverRK4 : ISolver
    {
        public VectorF Solve(ContinousModel mdl, VectorF state, float u, float t, float h)
        {
            VectorF k1 = h * mdl.DifferentialEquasions(state, u, t);
            VectorF k2 = h * mdl.DifferentialEquasions(state + 0.5f * k1, u, t);
            VectorF k3 = h * mdl.DifferentialEquasions(state + 0.5f * k2, u, t);
            VectorF k4 = h * mdl.DifferentialEquasions(state + k3, u, t);

            return state + 1.0f / 6.0f * (k1 + 2 * k2 + 2 * k3 + k4);
        }
    }
}
