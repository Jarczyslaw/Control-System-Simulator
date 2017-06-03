using JTControlSystem.SignalGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTControlSystem.Examples
{
    public abstract class BaseGeneratorExample : IExample
    {
        protected List<SignalSample> samples;

        public double[] GetTime()
        {
            return samples.Select(s => s.time).ToArray();
        }

        public double[] GetValues()
        {
            return samples.Select(s => s.value).ToArray();
        }

        public virtual void Run()
        {
            samples = GetSamples();
        }

        public virtual List<SignalSample> GetSamples()
        {
            return new List<SignalSample>();
        }
    }
}
