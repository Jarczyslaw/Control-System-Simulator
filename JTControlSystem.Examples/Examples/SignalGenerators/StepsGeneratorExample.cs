using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JTControlSystem.SignalGenerators;

namespace JTControlSystem.Examples
{
    public class StepsGeneratorExample : BaseGeneratorExample
    {
        public override List<SignalSample> GetSamples()
        {
            StepsGenerator steps = new StepsGenerator(new double[] { 3d, 10d, 14d }, new double[] { 1d, 4d, -2d });
            SignalSampler samplers = new SignalSampler(steps);
            return samplers.GetSamples(20d, 0.1d);
        }
    }
}
