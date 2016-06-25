using MathNet.Numerics.LinearAlgebra;

namespace JTSim
{
    public abstract class ContinousModel
    {
        public Vector<float> initState;

        public abstract Vector<float> DifferentialEquasions(Vector<float> state, float input, float t);

        public abstract float OutputEquation(Vector<float> state, float input);
    }
}
