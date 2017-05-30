using JTMath;

namespace JTControlSystem.Systems
{ 
    public interface IDiscreteModel
    {
        double DifferenceEquation(Vector states, Vector inputs, double time, double dt);
        double OutputEquation(Vector states, Vector inputs);
        int GetInputOrder { get; }
        int GetOrder { get; }
    }
}
