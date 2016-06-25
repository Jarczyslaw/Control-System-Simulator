using MathNet.Numerics.LinearAlgebra;

namespace JTSim
{
    public interface ISolver
    {
        Vector<float> Solve(ContinousModel model, Vector<float> state, float input, float t, float h);
    }
}
