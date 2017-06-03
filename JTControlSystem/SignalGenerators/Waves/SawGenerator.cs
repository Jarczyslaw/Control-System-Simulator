using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTControlSystem.SignalGenerators
{
    public class SawGenerator : BaseWaveGenerator, ISignalGenerator
    {
        public SawGenerator() { }

        public SawGenerator(double frequency, double amplitude, double valueOffset)
        {
            SetParameters(frequency, amplitude, valueOffset);
        }

        public SignalSample GetSample(double t)
        {
            var newSample = new SignalSample()
            {
                time = t,
                value = Saw(t)
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
