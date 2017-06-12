using JTMath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTControlSystem.Models.Discrete
{
    public class DiscreteSecondOrder : IDiscreteModel
    {
        double k = 2d;
        double T1 = 1d;
        double T2 = 1d;

        public DiscreteSecondOrder() { }

        public DiscreteSecondOrder(double k, double T1, double T2)
        {
            this.k = k;
            this.T1 = T1;
            this.T2 = T2;
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
                return 2;
            }
        }

        public double DifferenceEquation(Vector states, Vector inputs, double time, double dt)
        {
            double A = dt * dt + dt * (T1 + T2) + T1 * T2;
            double B = -2d * T1 * T2 - dt * (T1 + T2);
            double C = T1 * T2;
            double D = k * dt * dt;

            return -B / A * states[0] - C / A * states[1] + D / A * inputs[0];
        }

        public double OutputEquation(Vector states, Vector inputs)
        {
            return states[0];
        }
    }
}
