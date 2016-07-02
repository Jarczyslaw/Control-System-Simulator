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

        public List<double[]> data = new List<double[]>();
        public Modes mode = Modes.OpenLoop;

        public double h { get; private set; }

        private GenericSystem system;
        private GenericRegulator regulator;

        public int iteration { get; private set; } = -1;

        public Simulator (double h)
        {
            this.h = h;
        }

        public Simulator (double h, GenericSystem system, GenericRegulator regulator) : this(h)
        {
            this.system = system;
            this.regulator = regulator;
        }

        public double[] Step(double input)
        {
            iteration++;
            double time = GetCurrentTime();
            double controlValue;
            if (iteration == 0)
            {
                controlValue = GetControlValue(input, system.output);
            }
            else
            {
                controlValue = GetControlValue(input, system.output);
                system.Step(controlValue, time - h, h);
            }

            double[] newData = new double[] { time, input, controlValue, system.output };
            data.Add(newData);
            return newData;
        }

        private double GetControlValue (double input, double processValue)
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

        public void SetOpenLoop()
        {
            mode = Modes.OpenLoop;
        }

        public void SetClosedLoop()
        {
            mode = Modes.ClosedLoop;
        }

        public void ToggleMode ()
        {
            if (mode == Modes.OpenLoop)
                mode = Modes.ClosedLoop;
            else
                mode = Modes.OpenLoop;
        }

        public void StepSimulation(double time)
        {
            StepsGenerator sg = new StepsGenerator(1f);
            SignalSimulation(time, sg);
        }

        public void SignalSimulation(double time, ISignalGenerator generator)
        {
            Init();
            for (double t = 0d; t <= time; t += h)
                Step(generator.GetSample(t));
        }

        public double GetCurrentTime()
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
