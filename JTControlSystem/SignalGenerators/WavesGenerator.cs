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
        public WaveType wave = WaveType.Sine;

        private Dictionary<WaveType, BaseWaveGenerator> generators;

        public WavesGenerator()
        {
            generators = new Dictionary<WaveType, BaseWaveGenerator>();
            generators.Add(WaveType.Saw, new SawGenerator());
            generators.Add(WaveType.Sine, new SineGenerator());
            generators.Add(WaveType.Square, new SquareGenerator());
            generators.Add(WaveType.Triangle, new TriangleGenerator());
        }
    }
}
