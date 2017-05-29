using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTControlSystem.SignalGenerators
{
    public class SineGenerator : BaseWaveGenerator, ISignalGenerator
    {
        public double phase = 0d;

        public SignalGeneratorSample GetSample(double t)
        {
            var newSample = new SignalGeneratorSample()
            {
                time = t,
                sampleValue = Sine(t)
            };
            return newSample;
        }

        private double Sine(double t)
        {
            return amplitude * Math.Sin(2d * Math.PI * frequency * t + phase) + valueOffset;
        }
    }
}
