using JVectors;

namespace JTSim
{
    public interface ISolver
    {
        // stan oraz czas brany jest z poprzedniej iteracji i-1, wejscie z aktualnej i
        JVector Solve(ContinousModel model, JVector state, double input, double t, double h);

        void Init(double h);
    }
}
