using System;
using MathNet.Numerics.LinearAlgebra;

namespace JTSim
{
    public class AlphaFilter2 : DiscreteModel
    {
        double k = 1d;
        double T = 1d;

        public AlphaFilter2 (double initState)
        {
            this.initStates = Vector<double>.Build.Dense(1, initState);
            this.initInputs = Vector<double>.Build.Dense(1, 0d);
        }

        public override double DifferenceEquasion(Vector<double> states, Vector<double> inputs, double t, double h)
        {
            double alpha = (double)Math.Exp(-h / T);
            return states[0] * alpha + (1d - alpha) * k * inputs[0]; 
        }

        public override double OutputEquation(Vector<double> states, Vector<double> inputs)
        {
            return states[0];
        }
    }
}
