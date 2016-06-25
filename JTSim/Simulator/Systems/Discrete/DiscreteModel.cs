using MathNet.Numerics.LinearAlgebra;

namespace JTSim
{
    public abstract class DiscreteModel
    {
        public Vector<double> initStates;
        public Vector<double> initInputs;

        public abstract double DifferenceEquasion(Vector<double> states, Vector<double> inputs, double t, double h);

        public abstract double OutputEquation(Vector<double> states, Vector<double> inputs);
    }
}
