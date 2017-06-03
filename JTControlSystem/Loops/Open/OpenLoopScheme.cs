using JTControlSystem.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTControlSystem
{
    /// <summary>
    /// Wrapper around system which implements control on the system itself. On initialize it returns system initial output
    /// and in the next iteration returns system's output based on input value
    /// </summary>
    public class OpenLoopScheme
    {
        private ISystem system;

        public OpenLoopScheme(ISystem system)
        {
            this.system = system;
        }

        public OpenLoopDataSample NextIteration(double dt, double currentTime,
            double input)
        {
            double systemOutput = system.NextIteration(input, currentTime - dt, dt);
            return new OpenLoopDataSample(currentTime, input, systemOutput); ;
        }

        public OpenLoopDataSample Initialize(double dt, double currentTime)
        {
            double initialOutput = system.Initialize(dt);
            return new OpenLoopDataSample(currentTime, 0d, initialOutput); ;
        }
    }
}
