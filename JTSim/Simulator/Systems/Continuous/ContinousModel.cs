using MathNet.Numerics.LinearAlgebra;

namespace JTSim
{
    public abstract class ContinousModel
    {
        public Vector<double> initState;

        public abstract Vector<double> DifferentialEquasions(Vector<double> state, double input, double t);

        public abstract double OutputEquation(Vector<double> state, double input);
    }
}
