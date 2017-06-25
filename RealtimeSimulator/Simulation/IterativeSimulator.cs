using JTControlSystem;
using JTControlSystem.Controllers;
using JTControlSystem.SignalGenerators;
using JTControlSystem.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtimeSimulator
{
    public class IterativeSimulator
    {
        public int Iteration { get; private set; }
        private double dt; 

        public ControlSystem ControlSystem { get; private set; }

        public SignalsGenerator SignalsGenerator { get; private set; }
        public SignalType signalType;
        public bool manualInput;
        public double inputValue;
        public double setPointValue;

        public IterativeSimulator(ISystem system, IController controller)
        {
            ControlSystem = new ControlSystem(system, controller);
            SignalsGenerator = new SignalsGenerator();
        }

        public ControlSystemDataSample Initialize(double dt)
        {
            this.dt = dt;
            Iteration = 0;

            ControlSystem.Initialize(dt);
            return GetLastSample();
        }

        public ControlSystemDataSample NextIteration()
        {
            Iteration++;
            var inputValue = GetInputValue(CurrentTime);
            ControlSystem.NextIteration(inputValue, CurrentTime, dt);
            return GetLastSample();
        }

        private double GetInputValue(double time)
        {
            if (manualInput)
            {
                if (ControlSystem.mode == ControlSystemMode.OpenLoop)
                    return inputValue;
                else
                    return setPointValue;
            }
            else
                return SignalsGenerator.GetSample(signalType, time).value;
        }

        public double CurrentTime
        {
            get { return Iteration * dt; }
        }

        public ControlSystemDataSample GetLastSample()
        {
            return ControlSystem.Data.Last();
        }

        public List<ControlSystemDataSample> GetData()
        {
            return ControlSystem.Data;
        }
    }
}
