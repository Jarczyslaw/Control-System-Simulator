using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JTMath;

namespace JTControlSystem.Models
{
    public class AlphaFilter : IDiscreteModel
    {
        private double k = 2d;
        private double T = 3d;

        public AlphaFilter() { }

        public AlphaFilter(double k, double T)
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
            double alpha = Math.Exp(-dt / T);
            return states[0] * alpha + (1d - alpha) * inputs[0] * k;
        }

        public double OutputEquation(Vector states, Vector inputs)
        {
            return states[0];
        }
    }
}
