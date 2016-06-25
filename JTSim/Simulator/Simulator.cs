using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace JTSim
{
    public class Simulator
    {
        public enum Modes
        {
            OpenLoop, ClosedLoop
        }

        public List<float[]> data = new List<float[]>();
        public Modes mode = Modes.OpenLoop;

        public float h { get; private set; }

        private GenericSystem system;
        private GenericRegulator regulator;

        public int iteration { get; private set; } = -1;
        private bool log = true;

        public Simulator (float h)
        {
            this.h = h;
        }

        public Simulator (float h, GenericSystem system, GenericRegulator regulator) : this(h)
        {
            this.system = system;
            this.regulator = regulator;
        }

        public float[] Step(float input)
        {
            iteration++;
            float time = GetCurrentTime();
            float controlValue;
            if (iteration == 0)
            {
                controlValue = GetControlValue(input, system.output);
            }
            else
            {
                controlValue = GetControlValue(input, system.output);
                system.Step(controlValue, time, h);
            }

            float[] newData = new float[] { time, input, controlValue, system.output };
            if (log)
                data.Add(newData);
            return newData;
        }

        private float GetControlValue (float input, float processValue)
        {
            if (mode == Modes.OpenLoop)
                return input;
            else 
                return regulator.Step(input, processValue, h);
        }

        public void AddSystem (GenericSystem system)
        {
            this.system = system;
        }

        public void AddRegulator (GenericRegulator regulator)
        {
            this.regulator = regulator;
        }

        public void StepSimulation(float time)
        {
            StepsGenerator sg = new StepsGenerator(1f);
            SignalSimulation(time, sg);
        }

        public void SignalSimulation(float time, ISignalGenerator generator)
        {
            Init();
            int iterations = (int)Math.Round(time / h);
            for (int i = 0; i < iterations; i++)
            {
                data.Add(Step(generator.GetSample(i * h)));
            }
        }

        public float GetCurrentTime()
        {
            return iteration * h;
        }

        public void Init ()
        {
            iteration = -1;
            data.Clear();
            system.Init(h);
            regulator.Init(h);
        }
    }
}
