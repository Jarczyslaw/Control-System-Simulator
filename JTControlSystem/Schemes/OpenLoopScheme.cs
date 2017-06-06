using JTControlSystem.Controllers;
using JTControlSystem.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTControlSystem
{
    /// <summary>
    /// Wrapper around system and controller which implements open loop scheme control. It initializes all dynamic objects
    /// and provides one step iteration. Controller's output is not affected by system's output (there is no error information)
    /// </summary>
    public class OpenLoopScheme
    {
        private ISystem system;
        private IController controller;

        public OpenLoopScheme(ISystem system, IController controller)
        {
            this.system = system;
            this.controller = controller;
        }

        public OpenLoopDataSample NextIteration(double dt, double currentTime, double setValue)
        {
            double controllerOutput = controller.NextIteration(setValue, 0d, dt);
            double systemOutput = system.NextIteration(controllerOutput, currentTime - dt, dt);
            OpenLoopDataSample dataSample = new OpenLoopDataSample()
            {
                time = currentTime,
                setValue = setValue,
                controllerOutput = controllerOutput,
                systemOutput = systemOutput
            };
            return dataSample;
        }

        public OpenLoopDataSample Initialize(double dt, double currentTime)
        {
            controller.Initialize(dt);
            double systemOutput = system.Initialize(dt);
            OpenLoopDataSample dataSample = new OpenLoopDataSample()
            {
                time = currentTime,
                setValue = 0d,
                controllerOutput = 0d,
                systemOutput = systemOutput
            };
            return dataSample;
        }
    }
}
