using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTControlSystem.Examples
{
    public class ControlSystemExample : BaseLoopExample, IExample
    {
        private List<ControlSystemDataSample> data;

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
            ControlSystem loop = new ControlSystem(system, controller, 0.01d);
            loop.mode = ControlSystemMode.OpenLoop;

            var toggler = new ControlSystemModeToggler(loop.mode, 3d, 6d);
            Simulator.Step(loop, 10d, (iteration, time) =>
            {
                loop.mode = toggler.GetMode(time);
            });
            data = loop.Data;
        }
    }
}
