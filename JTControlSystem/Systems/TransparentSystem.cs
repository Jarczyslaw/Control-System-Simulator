using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTControlSystem.Systems
{
    public class TransparentSystem : ISystem
    {
        public double NextIteration(double input, double time, double dt)
        {
            return input;
        }

        public double Initialize(double dt)
        {
            return 0d;
        }
    }
}
