using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JTMath;

namespace JTControlSystem.Systems
{
    public class TransparentContinousModel : IContinousModel
    {
        public int GetOrder
        {
            get
            {
                return 1;
            }
        }

        public Vector DifferentialEquations(Vector state, double input, double time)
        {
            return state;
        }

        public double OutputEquation(Vector state, double input)
        {
            return state[0];
        }
    }
}
