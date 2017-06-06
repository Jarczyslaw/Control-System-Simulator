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
    public class ControlSystem : BaseLoop
    {
        public List<ControlSystemDataSample> Data;

        private BareSystemScheme openScheme;
        private CloseLoopScheme closeScheme;

        public ControlSystemMode mode = ControlSystemMode.CloseLoop;

        #region CONSTRUCTORS

        public ControlSystem() : 
            this(new TransparentSystem(), new TransparentController(), Consts.defaultTimeStep) { }

        public ControlSystem(ISystem system) : 
            this(system, new TransparentController(), Consts.defaultTimeStep) { }

        public ControlSystem(ISystem system, double dt) : 
            this(system, new TransparentController(), dt) { }

        public ControlSystem(IController controller) : 
            this(new TransparentSystem(), controller, Consts.defaultTimeStep) { }

        public ControlSystem(IController controller, double dt) : 
            this(new TransparentSystem(), controller, dt) { }

        public ControlSystem(ISystem system, IController controller) : 
            this(system, controller, Consts.defaultTimeStep) { }

        public ControlSystem(ISystem system, IController controller, double dt)
        {
            this.Dt = dt;
            openScheme = new BareSystemScheme(system);
            closeScheme = new CloseLoopScheme(system, controller);
            Data = new List<ControlSystemDataSample>();
            Initialize();
        }

        #endregion

        public override void NextIteration(double input)
        {
            iteration++;
            ControlSystemDataSample dataSample;
            if (mode == ControlSystemMode.OpenLoop)
            {
                var openData = openScheme.NextIteration(Dt, CurrentTime, input);
                dataSample = ControlSystemDataSample.FromOpenSample(openData);
            }
            else
            {
                double previousSystemOutput = Data.Last().systemOutput;
                var closeData = closeScheme.NextIteration(Dt, CurrentTime,
                    input, previousSystemOutput);
                dataSample = ControlSystemDataSample.FromCloseSample(closeData);
            }
            Data.Add(dataSample);
        }

        public override void Initialize()
        {
            base.Initialize();
            Data.Clear();
            ControlSystemDataSample dataSample;
            if (mode == ControlSystemMode.OpenLoop)
            {
                dataSample = ControlSystemDataSample.FromOpenSample(openScheme.Initialize(Dt, CurrentTime));
                Data.Add(dataSample);
            }
            else
            {
                dataSample = ControlSystemDataSample.FromCloseSample(closeScheme.Initialize(Dt, CurrentTime));
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
