using JTControlSystem.SignalGenerators;
using JTControlSystem.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTControlSystem
{
    public class BareSystem : ILoop
    {
        public List<BareSystemDataSample> Data { get; private set; }
        private BareSystemScheme scheme;

        #region CONSTRUCTORS

        public BareSystem() : this(new TransparentSystem()) { }

        public BareSystem(ISystem system)
        {
            scheme = new BareSystemScheme(system);
            Data = new List<BareSystemDataSample>();
        }

        #endregion

        public void NextIteration(double input, double time, double dt)
        {
            var dataSample = scheme.NextIteration(input, time, dt);
            Data.Add(dataSample);
        }

        public BareSystemDataSample GetLastDataSample()
        {
            return Data.Last();
        }

        public void Initialize(double dt)
        {
            Data.Clear();
            var initialData = scheme.Initialize(0d, dt);
            Data.Add(initialData);
        }
    }
}
