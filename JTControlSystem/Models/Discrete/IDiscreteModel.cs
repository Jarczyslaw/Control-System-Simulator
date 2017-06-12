using JTMath;

namespace JTControlSystem.Models
{ 
    public interface IDiscreteModel
    {
        double DifferenceEquation(Vector states, Vector inputs, double time, double dt);
        double OutputEquation(Vector states, Vector inputs);
        int GetInputOrder { get; }
        int GetOutputOrder { get; }
    }
}
