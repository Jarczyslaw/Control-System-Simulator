using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTSim
{
    public class WaveGenerator : ISignalGenerator
    {
        public enum Waves
        {
            Sine, Square, Triangle, Saw
        }

        public float frequency = 1f;
        public float amplitude = 1f;
        public float offset = 0f;

        public Waves wave = Waves.Square;

        private Waves[] wavesArray;

        public WaveGenerator ()
        {
            wavesArray = new Waves[] { Waves.Sine, Waves.Square, Waves.Triangle, Waves.Saw };
        }

        public WaveGenerator(float frequency, float amplitude, float offset) : this()
        {
            this.frequency = frequency;
            this.amplitude = amplitude;
            this.offset = offset;
        }

        public WaveGenerator(Waves wave, float frequency, float amplitude, float offset) : this(frequency, amplitude, offset)
        {
            this.wave = wave;
        }

        private float Sine(float t)
        {
            float phase = 0f;
            return amplitude * (float)Math.Sin(2f * Math.PI * frequency * t + phase) + offset;
        }

        private float Square(float t)
        {
            float fill = 0.5f;
            float period = 1f / frequency;
            if (t % period < (period * fill))
                return amplitude + offset;
            else
                return -amplitude + offset;
        }

        private float Triangle(float t)
        {
            float period = 1f / frequency;
            float a = period / 2f;
            float q = (float)Math.Floor(t / a + 0.5f);
            return amplitude * 2f / a * (t - a * q) * (float)Math.Pow(-1, q) + offset;
        }

        private float Saw(float t)
        {
            float period = 1f / frequency;
            float q = t / period;
            return amplitude * 2f * (q - (float)Math.Floor(0.5f + q)) + offset;
        }

        public float GetSample(float t)
        {
            return GetSample(wave, t);
        }

        public float GetSample(int i, float t)
        {
            return GetSample(wavesArray[i], t);
        }

        public float GetSample(Waves wave, float t)
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

        public List<float[]> GetWaves (float time, float h)
        {
            List<float[]> samples = new List<float[]>();
            for (float t = 0f;t < time;t += h)
            {
                float[] s = new float[5];
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
