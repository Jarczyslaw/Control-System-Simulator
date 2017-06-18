using JTControlSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTControlSystemExamples
{
    public class OpenLoopExample : BaseLoopExample, IExample
    {
        private List<OpenLoopDataSample> data;

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
            OpenLoop loop = new OpenLoop(system, controller);
            Simulator.Step(loop, 10d, 0.1d);
            data = loop.Data;
        }
    }
}
