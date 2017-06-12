using System;
using JTMath;

namespace JTControlSystem.Models
{
    public class DiscreteFirstOrder : IDiscreteModel
    {
        private double k = 2d;
        private double T = 1d;

        public DiscreteFirstOrder() { }

        public DiscreteFirstOrder(double k, double T)
        {
            this.k = k;
            this.T = T;
        }

        public int GetInputOrder
        {
            get
            {
                return 1;
            }
        }

        public int GetOutputOrder
        {
            get
            {
                return 1;
            }
        }

        public double DifferenceEquation(Vector states, Vector inputs, double time, double dt)
        {
            return (1d - dt / T) * states[0] + k * dt / T * inputs[0];
        }

        public double OutputEquation(Vector states, Vector inputs)
        {
            return states[0];
        }
    }
}
