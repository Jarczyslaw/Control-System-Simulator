using System;
using MathNet.Numerics.LinearAlgebra;
using VectorF = MathNet.Numerics.LinearAlgebra.Vector<float>;

namespace JTSim
{
    public class SolverEuler : ISolver
    {
        public VectorF Solve(ContinousModel mdl, VectorF state, float u, float t, float h)
        {
            VectorF diffs = mdl.DifferentialEquasions(state, u, t);
            return state + h * diffs;
        }
    }
}
