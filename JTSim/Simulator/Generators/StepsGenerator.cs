using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTSim
{
    public class StepsGenerator : ISignalGenerator
    {
        public double[] stepTimes;
        public double[] stepValues;

        public StepsGenerator(double[] stepTimes, double[] stepValues)
        {
            SetParams(stepTimes, stepValues);
        }

        public StepsGenerator(double stepValue) : this(stepValue, 0d) { }

        public StepsGenerator(double stepValue, double stepTime)
        {
            stepTimes = new double[] { stepTime };
            stepValues = new double[] { stepValue };
        }

        public void SetParams(double[] stepTimes, double[] stepValues)
        {
            this.stepTimes = stepTimes;
            this.stepValues = stepValues;
            Array.Sort(stepTimes, stepValues);
        }

        public bool ValidParams(string times, string values, out double[] tim, out double[] val)
        {
            bool valid = false;
            tim = null; val = null;
            string[] t = times.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            string[] v = values.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (t.Length == v.Length && t.Length != 0 && v.Length != 0)
            {
                int len = t.Length;
                double[] newTimes = new double[len];
                double[] newValues = new double[len];
                int cnt = 0;
                for (int i = 0;i < len;i++)
                {
                    double nt = 0;
                    double nv = 0;
                    if (double.TryParse(t[i], out nt) && double.TryParse(v[i], out nv))
                    {
                        if (nt >= 0 && nv >= 0)
                        {
                            newTimes[i] = nt;
                            newValues[i] = nv;
                            cnt++;
                        }
                        else
                            break;
                    }
                    else
                        break;
                }

                if (cnt == len)
                {
                    tim = newTimes;
                    val = newValues;
                    valid = true;
                }
            }

            return valid;
        }

        public double GetSample(double t)
        {
            double result = 0d;
            if (t >= stepTimes[stepTimes.Length - 1])
                result = stepValues[stepValues.Length - 1];
            for (int i = 0; i < stepTimes.Length - 1; i++)
            {
                if (t >= stepTimes[i] && t < stepTimes[i + 1])
                    result = stepValues[i];
            }
            return result;
        }

        public List<double[]> GetSteps(double time, double h)
        {
            List<double[]> samples = new List<double[]>();
            for (double t = 0d; t < time; t += h)
            {
                double[] s = new double[2];
                s[0] = t;
                s[1] = GetSample(t);
                samples.Add(s);
            }
            return samples;
        }
    }
}
