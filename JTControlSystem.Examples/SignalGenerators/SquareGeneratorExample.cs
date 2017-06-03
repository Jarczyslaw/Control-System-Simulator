using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JTControlSystem.SignalGenerators;

namespace JTControlSystem.Examples
{
    public class SquareGeneratorExample : BaseGeneratorExample
    {
        public override List<SignalSample> GetSamples()
        {
            SquareGenerator square = new SquareGenerator(0.2d, 3d, 0d, 0.2d);
            SignalSampler sampler = new SignalSampler(square);
            return sampler.GetSamples(20d, 0.1d);
        }
    }
}
