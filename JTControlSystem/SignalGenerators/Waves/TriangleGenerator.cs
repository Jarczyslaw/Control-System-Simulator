using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTControlSystem.SignalGenerators
{
    public class TriangleGenerator : BaseWaveGenerator, ISignalGenerator
    {
        public TriangleGenerator() { }

        public TriangleGenerator(double frequency, double amplitude, double valueOffset)
        {
            SetParameters(frequency, amplitude, valueOffset);
        }

        public SignalSample GetSample(double t)
        {
            var newSample = new SignalSample()
            {
                time = t,
                value = Triangle(t)
            };
            return newSample;
        }

        private double Triangle(double t)
        {
            double period = 1d / frequency;
            double a = period / 2d;
            double q = Math.Floor(t / a + 0.5d);
            return amplitude * 2d / a * (t - a * q) * Math.Pow(-1d, q) + valueOffset;
        }
    }
}
