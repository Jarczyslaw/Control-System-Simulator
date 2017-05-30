using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JTMath;

namespace JTControlSystem.Systems
{
    public class ContinousFirstOrder : IContinousModel
    {
        public double k = 1.0d;
        public double T = 1.0d;

        public ContinousFirstOrder(double k, double T)
        {
            this.k = k;
            this.T = T;
        }

        public int GetOrder
        {
            get
            {
                return 1;
            }
        }

        public Vector DifferentialEquations(Vector state, double input, double time)
        {
            Vector diff = -1.0d / T * state + k / T * input;
            return diff;
        }

        public double OutputEquation(Vector state, double input)
        {
            return state[0];
        }
    }
}
