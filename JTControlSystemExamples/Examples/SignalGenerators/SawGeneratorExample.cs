using JTControlSystem.SignalGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTControlSystemExamples
{
    public class SawGeneratorExample : BaseGeneratorExample
    {
        public override List<SignalSample> GetSamples()
        {
            SawGenerator saw = new SawGenerator(0.1d, 5d, -1d);
            SignalSampler sampler = new SignalSampler(saw);
            return sampler.GetSamples(20d, 0.1d);
        }
    }
}
