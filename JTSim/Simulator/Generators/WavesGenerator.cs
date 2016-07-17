using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTSim
{
    public class WavesGenerator : ISignalGenerator
    {
        public enum Waves
        {
            Sine, Square, Triangle, Saw
        }

        public double frequency = 1d;
        public double amplitude = 1d;
        public double offset = 0d;

        public Waves wave = Waves.Square;

        private Waves[] wavesArray;

        public WavesGenerator ()
        {
            wavesArray = new Waves[] { Waves.Sine, Waves.Square, Waves.Triangle, Waves.Saw };
        }

        public WavesGenerator(double frequency, double amplitude, double offset) : this()
        {
            SetParams(frequency, amplitude, offset);
        }

        public WavesGenerator(Waves wave, double frequency, double amplitude, double offset) : this(frequency, amplitude, offset)
        {
            this.wave = wave;
        }

        public void SetParams(double frequency, double amplitude, double offset)
        {
            this.frequency = frequency;
            this.amplitude = amplitude;
            this.offset = offset;
        }

        public void SetParams(int defaultType, double frequency, double amplitude, double offset)
        {
            wave = wavesArray[defaultType];
            SetParams(frequency, amplitude, offset);
        }

        public bool ValidParams(string freq, string amp, string off, 
            ref double frequency, ref double amplitude, ref double offset)
        {
            bool valid = false;
            if (double.TryParse(amp, out amplitude) &&
                double.TryParse(freq, out frequency) &&
                double.TryParse(off, out offset))
            {
                if (amplitude > 0.0 && frequency > 0.0)
                    valid = true;
            }
            return valid;
        }

        private double Sine(double t)
        {
            double phase = 0d;
            return amplitude * Math.Sin(2d * Math.PI * frequency * t + phase) + offset;
        }

        private double Square(double t)
        {
            double fill = 0.5d;
            double period = 1d / frequency;
            if (t % period < (period * fill))
                return amplitude + offset;
            else
                return -amplitude + offset;
        }

        private double Triangle(double t)
        {
            double period = 1d / frequency;
            double a = period / 2d;
            double q = (double)Math.Floor(t / a + 0.5d);
            return amplitude * 2d / a * (t - a * q) * (double)Math.Pow(-1d, q) + offset;
        }

        private double Saw(double t)
        {
            double period = 1d / frequency;
            double q = t / period;
            return amplitude * 2d * (q - (double)Math.Floor(0.5d + q)) + offset;
        }

        public double GetSample(double t)
        {
            return GetSample(wave, t);
        }

        public double GetSample(int i, double t)
        {
            return GetSample(wavesArray[i], t);
        }

        public double GetSample(Waves wave, double t)
        {
            if (wave == Waves.Sine)
                return Sine(t);
            else if (wave == Waves.Square)
                return Square(t);
            else if (wave == Waves.Triangle)
                return Triangle(t);
            else
                return Saw(t);
        }

        public List<double[]> GetWaves (double time, double h)
        {
            List<double[]> samples = new List<double[]>();
            for (double t = 0d;t < time;t += h)
            {
                double[] s = new double[5];
                s[0] = t;
                s[1] = Sine(t);
                s[2] = Square(t);
                s[3] = Triangle(t);
                s[4] = Saw(t);
                samples.Add(s);
            }
            return samples;
        }
    }
}
