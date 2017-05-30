using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JTMath;

namespace JTControlSystem.Systems
{
    public class TransparentDiscreteModel : IDiscreteModel
    {
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

        public double DifferenceEquation(Vector states, Vector inputs, double t, double h)
        {
            return states[0];
        }

        public double OutputEquation(Vector states, Vector inputs)
        {
            return states[0];
        }
    }
}
