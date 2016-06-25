using MathNet.Numerics.LinearAlgebra;

namespace JTSim
{
    public abstract class DiscreteModel
    {
        public Vector<float> initStates;
        public Vector<float> initInputs;

        public abstract float DifferenceEquasion(Vector<float> states, Vector<float> inputs, float t, float h);

        public abstract float OutputEquation(Vector<float> states, Vector<float> inputs);
    }
}
