using MathNet.Numerics.LinearAlgebra;

namespace JTSim
{
    public interface ISolver
    {
        Vector<double> Solve(ContinousModel model, Vector<double> state, double input, double t, double h);
    }
}
