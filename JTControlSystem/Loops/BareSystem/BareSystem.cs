using JTControlSystem.SignalGenerators;
using JTControlSystem.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTControlSystem
{
    public class BareSystem : BaseLoop
    {
        public List<BareSystemDataSample> Data { get; private set; }
        private BareSystemScheme scheme;

        #region CONSTRUCTORS

        public BareSystem() : this(new TransparentSystem(), Consts.defaultTimeStep) { }

        public BareSystem(ISystem system) : this(system, Consts.defaultTimeStep) { }

        public BareSystem(ISystem system, double dt)
        {
            this.Dt = dt;
            scheme = new BareSystemScheme(system);
            Data = new List<BareSystemDataSample>();
            Initialize();
        }

        #endregion

        public override void NextIteration(double input)
        {
            iteration++;
            var dataSample = scheme.NextIteration(Dt, CurrentTime, input);
            Data.Add(dataSample);
        }

        public BareSystemDataSample GetLastDataSample()
        {
            return Data.Last();
        }

        public override void Initialize()
        {
            base.Initialize();
            Data.Clear();
            var initialData = scheme.Initialize(Dt, CurrentTime);
            Data.Add(initialData);
        }
    }
}
