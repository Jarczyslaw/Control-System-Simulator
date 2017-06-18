using JTControlSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTControlSystemExamples
{
    public class CloseLoopExample : BaseLoopExample, IExample
    {
        private List<CloseLoopDataSample> data;

        public double[] GetTime()
        {
            return data.Select(d => d.time).ToArray();
        }

        public double[] GetValues()
        {
            return data.Select(d => d.systemOutput).ToArray();
        }

        public void Run()
        {
            CloseLoop loop = new CloseLoop(system, controller);
            Simulator.Step(loop, 1d, 0.01d);
            data = loop.Data;
        }
    }
}
