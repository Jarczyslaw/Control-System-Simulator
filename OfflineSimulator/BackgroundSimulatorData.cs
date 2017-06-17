using JTControlSystem;
using JTControlSystem.SignalGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfflineSimulator
{
    public class BackgroundSimulatorData
    {
        public double TimeHorizon { get; private set; }
        public double TimeStep { get; private set; }

        public ControlSystem ControlSystem { get; private set; }
        public ControlSystemMode initialMode = ControlSystemMode.CloseLoop;

        public WavesGenerator WavesGenerator { get; private set; }

        public bool togglerEnabled = false;
        public ControlSystemModeToggler Toggler { get; private set; }

        public BackgroundSimulatorData()
        {
            WavesGenerator = new WavesGenerator();
            Toggler = new ControlSystemModeToggler();
        }

        public void PrepareSimulation(double timeHorizon, double timeStep)
        {
            TimeHorizon = timeHorizon;
            TimeStep = timeStep;

            ControlSystem = new ControlSystem(SystemAndController.GetSystem(), SystemAndController.GetController(), timeStep);
            ControlSystem.mode = initialMode;
        }

        public int Iterations()
        {
            return (int)Math.Ceiling(TimeHorizon / TimeStep);
        }
    }
}
