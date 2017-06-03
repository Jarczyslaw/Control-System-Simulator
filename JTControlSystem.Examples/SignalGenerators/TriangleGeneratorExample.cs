using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JTControlSystem.SignalGenerators;

namespace JTControlSystem.Examples
{
    public class TriangleGeneratorExample : BaseGeneratorExample
    {
        public override List<SignalSample> GetSamples()
        {
            TriangleGenerator triangle = new TriangleGenerator(0.1d, 1d, 1d);
            SignalSampler sampler = new SignalSampler(triangle);
            return sampler.GetSamples(20d, 0.1d);
        }
    }
}
