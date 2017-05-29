using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTControlSystem.SignalGenerators
{
    public class BaseWaveGenerator
    {
        public double frequency;
        public double amplitude;
        public double valueOffset;

        public BaseWaveGenerator() : this(1d, 1d, 0d) { }

        public BaseWaveGenerator(double frequency, double amplitude, double valueOffset)
        {
            SetBaseParams(frequency, amplitude, valueOffset);
        }

        public void SetBaseParams(double frequency, double amplitude, double valueOffset)
        {
            this.frequency = frequency;
            this.amplitude = amplitude;
            this.valueOffset = valueOffset;
        }
    }
}
