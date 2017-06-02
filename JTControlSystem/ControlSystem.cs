using JTControlSystem.Controllers;
using JTControlSystem.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTControlSystem
{
    public class ControlSystem : BaseLoop
    {
        public List<ControlSystemDataSample> Data;

        private CloseLoop closeLoop;
        private OpenLoop openLoop;

        public ControlSystemMode mode = ControlSystemMode.CloseLoop;

        public ControlSystem(ISystem system, IController controller, double dt)
        {
            closeLoop = new CloseLoop(system, controller, dt);
            openLoop = new OpenLoop(system, dt);
            Data = new List<ControlSystemDataSample>();
        }

        public ControlSystemDataSample NextIteration(double input)
        {
            iteration++;
            ControlSystemDataSample dataSample;
            if (mode == ControlSystemMode.OpenLoop)
            {
                var openLoopData = openLoop.NextIteration(input);
                dataSample = ControlSystemDataSample.FromOpenSample(openLoopData);
            }
            else
            {
                var closeLoopData = closeLoop.NextIteration(input);
                dataSample = ControlSystemDataSample.FromCloseSample(closeLoopData);
            }
            Data.Add(dataSample);
            return dataSample;
        }

        public override void Initialize()
        {
            base.Initialize();
            Data.Clear();
        }

        public ControlSystemMode ToggleMode()
        {
            if (mode == ControlSystemMode.CloseLoop)
                mode = ControlSystemMode.OpenLoop;
            else
                mode = ControlSystemMode.CloseLoop;
            return mode;
        }
    }
}
