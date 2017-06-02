using JTControlSystem.Controllers;
using JTControlSystem.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTControlSystem
{
    public class CloseLoop : BaseLoop
    {
        public List<CloseLoopDataSample> Data { get; private set; }

        private IController controller;
        private ISystem system;

        public bool feedbackEnabled = true;

        private double previousSystemOutput;

        public CloseLoop() : 
            this(new TransparentSystem(), new TransparentController(), Consts.defaultTimeStep) { }

        public CloseLoop(ISystem system) : 
            this(system, new TransparentController(), Consts.defaultTimeStep) { }

        public CloseLoop(ISystem system, double dt) : 
            this(system, new TransparentController(), dt) { }

        public CloseLoop(IController controller) : 
            this(new TransparentSystem(), controller, Consts.defaultTimeStep) { }

        public CloseLoop(IController controller, double dt) : 
            this(new TransparentSystem(), controller, dt) { }

        public CloseLoop(ISystem system, IController controller) : 
            this(system, controller, Consts.defaultTimeStep) { }

        public CloseLoop(ISystem system, IController controller, double dt)
        {
            this.system = system;
            this.controller = controller;
            this.dt = dt;
            Data = new List<CloseLoopDataSample>();
        }

        public CloseLoopDataSample NextIteration(double setValue)
        {
            iteration++;
            double controllerOutput, systemOutput;
            if (iteration == 0)
            {
                controllerOutput = 0d;
                systemOutput = system.Initialize(dt);
            }
            else
            {
                controllerOutput = controller.NextIteration(setValue, previousSystemOutput, dt);
                systemOutput = system.NextIteration(controllerOutput, CurrentTime - dt, dt);
            }
            previousSystemOutput = systemOutput;
            CloseLoopDataSample dataSample = new CloseLoopDataSample()
            {
                time = CurrentTime,
                feedbackEnabled = feedbackEnabled,
                setValue = setValue,
                error = setValue - systemOutput,
                controllerOutput = controllerOutput,
                systemOutput = systemOutput
            };
            Data.Add(dataSample);
            return dataSample;
        }

        public bool ToggleFeedback()
        {
            feedbackEnabled = !feedbackEnabled;
            return feedbackEnabled;
        }

        public override void Initialize()
        {
            base.Initialize();
            Data.Clear();
        }
    }
}
