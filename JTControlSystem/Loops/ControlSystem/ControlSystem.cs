using JTControlSystem.Controllers;
using JTControlSystem.Systems;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTControlSystem
{
    public class ControlSystem : ILoop
    {
        public List<ControlSystemDataSample> Data;

        private BareSystemScheme openScheme;
        private CloseLoopScheme closeScheme;

        public ControlSystemMode mode = ControlSystemMode.CloseLoop;

        #region CONSTRUCTORS

        public ControlSystem() : this(new TransparentSystem(), new TransparentController()) { }

        public ControlSystem(ISystem system) :  this(system, new TransparentController()) { }

        public ControlSystem(IController controller) : this(new TransparentSystem(), controller) { }

        public ControlSystem(ISystem system, IController controller)
        {
            openScheme = new BareSystemScheme(system);
            closeScheme = new CloseLoopScheme(system, controller);
            Data = new List<ControlSystemDataSample>();
        }

        #endregion

        public void NextIteration(double input, double time, double dt)
        {
            ControlSystemDataSample dataSample;
            if (mode == ControlSystemMode.OpenLoop)
            {
                var openData = openScheme.NextIteration(input, time, dt);
                dataSample = ControlSystemDataSample.FromOpenSample(openData);
            }
            else
            {
                double previousSystemOutput = Data.Last().systemOutput;
                var closeData = closeScheme.NextIteration(input, previousSystemOutput, time, dt);
                dataSample = ControlSystemDataSample.FromCloseSample(closeData);
            }
            Data.Add(dataSample);
        }

        public void Initialize(double dt)
        {
            Data.Clear();
            ControlSystemDataSample dataSample;
            if (mode == ControlSystemMode.OpenLoop)
            {
                dataSample = ControlSystemDataSample.FromOpenSample(openScheme.Initialize(0d, dt));
                Data.Add(dataSample);
            }
            else
            {
                dataSample = ControlSystemDataSample.FromCloseSample(closeScheme.Initialize(0d, dt));
                Data.Add(dataSample);
            }
        }

        public ControlSystemDataSample GetLastDataSample()
        {
            return Data.Last();
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
