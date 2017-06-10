using System;
using JTControlSystem.Systems;
using JTMath;

namespace JTControlSystem.Models
{
    public class ContinousSecondOrder : IContinousModel
    {
        public double k = 1.0d;
        public double T1 = 1.0d;
        public double T2 = 1.0d;

        public ContinousSecondOrder(double k, double T1, double T2)
        {
            this.k = k;
            this.T1 = T1;
            this.T2 = T2;
        }

        public int GetOrder
        {
            get
            {
                return 2;
            }
        }

        public Vector DifferentialEquations(Vector state, double input, double t)
        {
            double d = T1 * T2;
            double first = state[1];
            double second = -(T1 + T2) / d * state[1] - 1d / d * state[0] + k / d * input;
            Vector diff = new Vector(new double[] { first, second });
            return diff;
        }

        public double OutputEquation(Vector state, double u)
        {
            return state[0];
        }
    }
}
