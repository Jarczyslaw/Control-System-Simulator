using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTControlSystem.Examples
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
            OpenLoop loop = new OpenLoop(system, controller, 0.1d);
            Simulator.Step(loop, 10d);
            data = loop.Data;
        }
    }
}
