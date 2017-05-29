using JTControlSystem.SignalGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST
{
    class Program
    {
        static void Main(string[] args)
        {
            var generator = new WavesGenerator();
            generator.GetSample(SignalType.Square, 0d);
            generator.GetSamples(SignalType.Steps, 5d, 10d, 1d);

            generator.SetSinePhase(1d);
            generator.SetWavesParameters(1d, 1d, 1d);

            Console.ReadKey();
        }
    }
}
