using JTControlSystem.SignalGenerators;
using JTControlSystem.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTControlSystem
{
    public class OpenLoop : BaseLoop
    {
        public List<OpenLoopDataSample> Data { get; private set; }
        private OpenLoopScheme scheme;

        #region CONSTRUCTORS

        public OpenLoop() : this(new TransparentSystem(), Consts.defaultTimeStep) { }

        public OpenLoop(ISystem system) : this(system, Consts.defaultTimeStep) { }

        public OpenLoop(ISystem system, double dt)
        {
            this.Dt = dt;
            scheme = new OpenLoopScheme(system);
            Data = new List<OpenLoopDataSample>();
            Initialize();
        }

        #endregion

        public override void NextIteration(double input)
        {
            iteration++;
            var dataSample = scheme.NextIteration(Dt, CurrentTime, input);
            Data.Add(dataSample);
        }

        public OpenLoopDataSample GetLastDataSample()
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
