using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTControlSystem.SignalGenerators
{
    public class SignalSampler
    {
        private ISignalGenerator generator;

        public SignalSampler(ISignalGenerator generator)
        {
            this.generator = generator;
        }

        public SignalGeneratorSample GetSample(double time)
        {
            return generator.GetSample(time);
        }

        public List<SignalGeneratorSample> GetSamples(double timeHorizon, double dt)
        {
            return GetSamples(0d, timeHorizon, dt);
        }

        public List<SignalGeneratorSample> GetSamples(double startTime, double timeHorizon, double dt)
        {
            List<SignalGeneratorSample> samples = new List<SignalGeneratorSample>();
            double endTime = startTime + timeHorizon;
            for (double t = startTime; t <= endTime; t += dt)
            {
                var newSample = generator.GetSample(t);
                samples.Add(newSample);
            }
            return samples;
        }
    }
}
