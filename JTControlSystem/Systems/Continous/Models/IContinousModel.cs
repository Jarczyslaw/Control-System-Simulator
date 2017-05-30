using JTMath;

namespace JTControlSystem.Systems
{
    public interface IContinousModel
    {
        Vector DifferentialEquations(Vector state, double input, double time);
        double OutputEquation(Vector state, double input);
        int GetOrder { get; }
    }
}
