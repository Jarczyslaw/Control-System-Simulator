using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTControlSystem.SignalGenerators
{
    public class TriangleGenerator : BaseWaveGenerator, ISignalGenerator
    {
        public SignalGeneratorSample GetSample(double t)
        {
            var newSample = new SignalGeneratorSample()
            {
                time = t,
                sampleValue = Triangle(t)
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
