using JTControlSystem.SignalGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTControlSystemExamples
{
    public class SineGeneratorExample : BaseGeneratorExample
    {
        public override List<SignalSample> GetSamples()
        {
            SineGenerator sine = new SineGenerator(0.2d, 2d, 1d, 90d);
            SignalSampler sampler = new SignalSampler(sine);
            return sampler.GetSamples(20d, 0.1d);
        }
    }
}
