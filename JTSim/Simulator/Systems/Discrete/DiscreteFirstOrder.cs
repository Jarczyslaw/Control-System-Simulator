using MathNet.Numerics.LinearAlgebra;

namespace JTSim
{
    public class DiscreteFirstOrder : DiscreteModel
    {
        public double k = 2.0d;
        public double T = 1.0d;

        public DiscreteFirstOrder(double initState)
        {
            this.initStates = Vector<double>.Build.Dense(1, initState);
            this.initInputs = Vector<double>.Build.Dense(1, 0d);
        }

        public DiscreteFirstOrder(double initState, double k, double T) : this(initState)
        {
            this.k = k;
            this.T = T;
        }

        public override double DifferenceEquasion(Vector<double> states, Vector<double> inputs, double t, double h)
        {
            return (1d - h / T) * states[0] + k * h / T * inputs[0];
        }

        public override double OutputEquation(Vector<double> states, Vector<double> inputs)
        {
            return states[0];
        }
    }
}
