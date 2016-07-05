using System;
using JVectors;

namespace JTSim
{
    public class AlphaFilter2 : DiscreteModel
    {
        double k = 1d;
        double T = 1d;

        public AlphaFilter2 (double initState)
        {
            this.initStates = new JVector(1, initState);
            this.initInputs = new JVector(1, 0d);
        }

        public override double DifferenceEquasion(JVector states, JVector inputs, double t, double h)
        {
            double alpha = (double)Math.Exp(-h / T);
            return states[0] * alpha + (1d - alpha) * k * inputs[0]; 
        }

        public override double OutputEquation(JVector states, JVector inputs)
        {
            return states[0];
        }
    }
}
