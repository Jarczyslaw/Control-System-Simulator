using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTControlSystem.SignalGenerators
{
    public class WavesGenerator
    {
        public SignalType wave = SignalType.Sine;

        private Dictionary<SignalType, ISignalGenerator> generators;

        public WavesGenerator()
        {
            generators = new Dictionary<SignalType, ISignalGenerator>();
            generators.Add(SignalType.Steps, new StepsGenerator());
            generators.Add(SignalType.Saw, new SawGenerator());
            generators.Add(SignalType.Sine, new SineGenerator());
            generators.Add(SignalType.Square, new SquareGenerator());
            generators.Add(SignalType.Triangle, new TriangleGenerator());
        }

        public SignalGeneratorSample GetSample(SignalType signalType, double time)
        {
            return generators[signalType].GetSample(time);
        }

        public List<SignalGeneratorSample> GetSamples(SignalType signalType, double timeHorizon, double dt)
        {
            var sampler = new SignalSampler(generators[signalType]);
            return sampler.GetSamples(timeHorizon, dt);

        }

        public List<SignalGeneratorSample> GetSamples(SignalType signalType, double startTime, double timeHorizon, double dt)
        {
            var sampler = new SignalSampler(generators[signalType]);
            return sampler.GetSamples(startTime, timeHorizon, dt);
        }

        public void SetStepsParameters(double[] times, double[] values)
        {
            var stepsGenerator = generators[SignalType.Steps] as StepsGenerator;
            stepsGenerator.SetParameters(times, values);
        }

        public void SetWavesParameters(double frequency, double amplitude, double offset)
        {
            foreach(KeyValuePair<SignalType, ISignalGenerator> keyValue in generators)
            {
                if (generators[keyValue.Key] is BaseWaveGenerator)
                {
                    var waveGenerator = generators[keyValue.Key] as BaseWaveGenerator;
                    waveGenerator.SetParameters(frequency, amplitude, offset);
                }
            }
        }

        public void SetSinePhase(double phase)
        {
            var sineGenerator = generators[SignalType.Sine] as SineGenerator;
            sineGenerator.phase = phase;
        }

        public void SetSquareFill(double fill)
        {
            var squareGenerator = generators[SignalType.Square] as SquareGenerator;
            squareGenerator.SetFill(fill);
        }
    }
}
