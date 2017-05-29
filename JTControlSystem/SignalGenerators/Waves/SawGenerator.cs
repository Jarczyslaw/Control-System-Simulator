using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTControlSystem.SignalGenerators
{
    public class SawGenerator : BaseWaveGenerator, ISignalGenerator
    {
        public SignalGeneratorSample GetSample(double t)
        {
            var newSample = new SignalGeneratorSample()
            {
                time = t,
                sampleValue = Saw(t)
            };
            return newSample;
        }

        private double Saw(double t)
        {
            double period = 1d / frequency;
            double q = t / period;
            return amplitude * 2d * (q - Math.Floor(0.5d + q)) + valueOffset;
        }
    }
}
