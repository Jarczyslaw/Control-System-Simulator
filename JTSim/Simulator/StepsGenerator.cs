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
        public float[] stepTimes;
        public float[] stepValues;

        public StepsGenerator(float[] stepTimes, float[] stepValues)
        {
            this.stepTimes = stepTimes;
            this.stepValues = stepValues;
            Array.Sort(stepTimes, stepValues);
        }

        public StepsGenerator(float stepValue)
        {
            stepTimes = new float[] { 0f };
            stepValues = new float[] { stepValue };
        }

        public float GetSample(float t)
        {
            float result = 0f;
            if (t >= stepTimes[stepTimes.Length - 1])
                result = stepValues[stepValues.Length - 1];
            for (int i = 0; i < stepTimes.Length - 1; i++)
            {
                if (t >= stepTimes[i] && t < stepTimes[i + 1])
                    result = stepValues[i];
            }
            return result;
        }

        public List<float[]> GetSteps(float time, float h)
        {
            List<float[]> samples = new List<float[]>();
            for (float t = 0f; t < time; t += h)
            {
                float[] s = new float[2];
                s[0] = t;
                s[1] = GetSample(t);
                samples.Add(s);
            }
            return samples;
        }
    }
}
