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

        public SignalSample GetSample(double time)
        {
            return generator.GetSample(time);
        }

        public List<SignalSample> GetSamples(double timeHorizon, double dt)
        {
            return GetSamples(0d, timeHorizon, dt);
        }

        public List<SignalSample> GetSamples(double startTime, double timeHorizon, double dt)
        {
            List<SignalSample> samples = new List<SignalSample>();
            double endTime = startTime + timeHorizon;
            for (double t = startTime; t <= endTime + dt; t += dt)
            {
                var newSample = generator.GetSample(t);
                samples.Add(newSample);
            }
            return samples;
        }
    }
}
