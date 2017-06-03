using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace JTControlSystem.SignalGenerators
{
    public class SineGenerator : BaseWaveGenerator, ISignalGenerator
    {
        public double phase = 0d;

        public SineGenerator() { }

        public SineGenerator(double frequency, double amplitude, double valueOffset) : 
            this(frequency, amplitude, valueOffset, 0d)
        { }

        public SineGenerator(double frequency, double amplitude, double valueOffset, double phase)
        {
            this.phase = phase;
            SetParameters(frequency, amplitude, valueOffset);
        }

        public SignalSample GetSample(double t)
        {
            var newSample = new SignalSample()
            {
                time = t,
                value = Sine(t)
            };
            return newSample;
        }

        private double Sine(double t)
        {
            return amplitude * Math.Sin(2d * Math.PI * frequency * t + Mathd.DegToRad(phase)) + valueOffset;
        }
    }
}
