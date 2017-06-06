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
    /// Wrapper around system and controller which implements close loop scheme control. It initializes all dynamic objects
    /// and provides one step iteration. On start, close loop returns initial output from system. In next iterations it returns
    /// system output based on controller output
    /// </summary>
    public class CloseLoopScheme
    {
        private ISystem system;
        private IController controller;

        public CloseLoopScheme(ISystem system, IController controller)
        {
            this.system = system;
            this.controller = controller;
        }

        public CloseLoopDataSample NextIteration(double dt, double currentTime,
            double setValue, double previousSystemOutput)
        {
            double error = setValue - previousSystemOutput;
            double controllerOutput = controller.NextIteration(error, previousSystemOutput, dt);
            double systemOutput = system.NextIteration(controllerOutput, currentTime - dt, dt);
            CloseLoopDataSample dataSample = new CloseLoopDataSample()
            {
                time = currentTime,
                setValue = setValue,
                error = error,
                controllerOutput = controllerOutput,
                systemOutput = systemOutput
            };
            return dataSample;
        }

        public CloseLoopDataSample Initialize(double dt, double currentTime)
        {
            controller.Initialize(dt);
            double systemOutput = system.Initialize(dt);
            CloseLoopDataSample dataSample = new CloseLoopDataSample()
            {
                time = currentTime,
                setValue = 0d,
                error = 0d,
                controllerOutput = 0d,
                systemOutput = systemOutput
            };
            return dataSample;
        }
    }
}
