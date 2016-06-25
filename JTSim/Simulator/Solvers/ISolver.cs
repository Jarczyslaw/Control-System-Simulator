using MathNet.Numerics.LinearAlgebra;

namespace JTSim
{
    public interface ISolver
    {
        // stan oraz czas brany jest z poprzedniej iteracji i-1, wejscie z aktualnej i
        Vector<double> Solve(ContinousModel model, Vector<double> state, double input, double t, double h);
    }
}
