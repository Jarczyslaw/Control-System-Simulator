using JTControlSystem.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTControlSystem.Examples
{
    public abstract class BaseModelExample : IExample
    {
        private List<BareSystemDataSample> data;

        public double[] GetTime()
        {
            return data.Select(d => d.time).ToArray();
        }

        public double[] GetValues()
        {
            return data.Select(d => d.output).ToArray();
        }

        public void Run()
        {
            BareSystem loop = new BareSystem(GetSystem());
            Simulator.Step(loop, 15d, 0.01d);
            data = loop.Data;
        }

        public abstract ISystem GetSystem();
    }
}
