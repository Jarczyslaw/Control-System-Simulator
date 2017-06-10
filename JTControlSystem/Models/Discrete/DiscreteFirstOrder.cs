using System;
using JTMath;

namespace JTControlSystem.Models
{
    public class DiscreteFirstOrder : IDiscreteModel
    {
        private double k = 2d;
        private double T = 1d;

        public int GetInputOrder
        {
            get
            {
                return 1;
            }
        }

        public int GetOrder
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
