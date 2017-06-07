using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTControlSystem.Examples
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
            CloseLoop loop = new CloseLoop(system, controller, 0.01d);
            Simulator.Step(loop, 1d);
            data = loop.Data;
        }
    }
}
