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
            data = GetSystemData();
        }

        public abstract List<BareSystemDataSample> GetSystemData();
    }
}
