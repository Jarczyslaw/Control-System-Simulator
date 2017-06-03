using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTControlSystem.SignalGenerators
{
    public abstract class BaseWaveGenerator
    {
        public double frequency = 1d;
        public double amplitude = 1d;
        public double valueOffset = 0d;

        public void SetParameters(double frequency, double amplitude, double valueOffset)
        {
            this.frequency = frequency;
            this.amplitude = amplitude;
            this.valueOffset = valueOffset;
        }
    }
}
