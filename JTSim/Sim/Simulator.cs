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

        public float[] Step(float setValue)
        {
            float time = iteration * h;
            float controlValue;
            if (iteration == -1)
            {
                system.Init();
                regulator.Init();
                controlValue = GetControlValue(setValue, system.output);
            }
            else
            {
                controlValue = GetControlValue(setValue, system.output);
                system.Step(controlValue, time);
            }

            float[] newData = new float[] { time, setValue, controlValue, system.output };
            if (log)
                data.Add(newData);
            iteration++;
            return newData;
        }

        private float GetControlValue (float setValue, float processValue)
        {
            if (mode == Modes.OpenLoop)
                return setValue;
            else 
                return regulator.Step(setValue, processValue);
        }

        public void AddSystem (GenericSystem system)
        {
            this.system = system;
            system.h = h;
        }

        public void AddRegulator (GenericRegulator regulator)
        {
            this.regulator = regulator;
            regulator.h = h;
        }

        public void Run ()
        {
            for (int i = 0; i < 1000; i++)
            {
                Step(1f);
            }
            for (int i = 0; i < 1000; i++)
            {
                Step(-1f);
            }
            for (int i = 0; i < 1000; i++)
            {
                Step(1f);
            }
            DataToFile ("D:\\data.txt");
        }

        public void Reset ()
        {
            iteration = -1;
        }

        public void DataToFile (string path)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < data.Count; i++)
            {
                for (int j = 0; j < data[i].Length; j++)
                {
                    sb.AppendFormat("{0:0.000000}", data[i][j]);
                    if (j != data[0].Length - 1)
                        sb.Append(", ");
                }
                sb.Append(Environment.NewLine);
            }
            File.WriteAllText(path, sb.ToString());
        }

    }
}
