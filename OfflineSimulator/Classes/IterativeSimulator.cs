using JTControlSystem;
using JTControlSystem.SignalGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfflineSimulator
{
    public class IterativeSimulator
    {
        public int Iteration { get; private set; }
        private double dt;

        public ControlSystem System { get; private set; }
        public ControlSystemMode initialMode;

        public SignalsGenerator SignalGenerator { get; private set; }
        public SignalType waveType;

        public IterativeSimulator()
        {
            var system = SystemAndController.GetSystem();
            var controller = SystemAndController.GetController();

            System = new ControlSystem(system, controller);
            SignalGenerator = new SignalsGenerator();
        }

        public void PrepareSimulation(double dt)
        {
            System.Initialize(dt);
            System.mode = initialMode;

            this.dt = dt;
            Iteration = 0;
        }

        public void NextIteration()
        {
            Iteration++;
            var inputSample = SignalGenerator.GetSample(waveType, CurrentTime);
            System.NextIteration(inputSample.value, CurrentTime, dt);
        }

        public double CurrentTime
        {
            get { return Iteration * dt; }
        }

        public List<ControlSystemDataSample> GetData()
        {
            return System.Data;
        }
    }
}
