using VectorF = MathNet.Numerics.LinearAlgebra.Vector<float>;

namespace JTSim
{
    public interface ISolver
    {
        VectorF Solve(ContinousModel mdl, VectorF state, float u, float t, float h);
    }
}
