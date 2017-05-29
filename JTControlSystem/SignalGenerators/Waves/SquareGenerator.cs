using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTControlSystem.SignalGenerators
{
    public class SquareGenerator : BaseWaveGenerator, ISignalGenerator
    {
        public double fill = 0.5d;

        public SignalGeneratorSample GetSample(double t)
        {
            var newSample = new SignalGeneratorSample()
            {
                time = t,
                sampleValue = Square(t)
            };
            return newSample;
        }

        private double Square(double t)
        {
            double period = 1d / frequency;
            if (t % period < (period * fill))
                return amplitude + valueOffset;
            else
                return -amplitude + valueOffset;
        }
    }
}
