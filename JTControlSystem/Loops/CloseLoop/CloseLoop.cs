using JTControlSystem.Controllers;
using JTControlSystem.SignalGenerators;
using JTControlSystem.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTControlSystem
{
    public class CloseLoop : BaseLoop
    {
        public List<CloseLoopDataSample> Data { get; private set; }

        private CloseLoopScheme scheme;

        #region CONSTRUCTORS

        public CloseLoop() : 
            this(new TransparentSystem(), new TransparentController(), Consts.defaultTimeStep) { }

        public CloseLoop(ISystem system) : 
            this(system, new TransparentController(), Consts.defaultTimeStep) { }

        public CloseLoop(ISystem system, double dt) : 
            this(system, new TransparentController(), dt) { }

        public CloseLoop(IController controller) : 
            this(new TransparentSystem(), controller, Consts.defaultTimeStep) { }

        public CloseLoop(IController controller, double dt) : 
            this(new TransparentSystem(), controller, dt) { }

        public CloseLoop(ISystem system, IController controller) : 
            this(system, controller, Consts.defaultTimeStep) { }

        public CloseLoop(ISystem system, IController controller, double dt)
        {
            this.Dt = dt;
            scheme = new CloseLoopScheme(system, controller);
            Data = new List<CloseLoopDataSample>();
            Initialize();
        }

        #endregion

        public override void NextIteration(double setValue)
        {
            iteration++;
            double previousSystemOutput = Data.Last().systemOutput;
            var dataSample = scheme.NextIteration(Dt, CurrentTime,
                setValue, previousSystemOutput);
            Data.Add(dataSample);
        }

        public CloseLoopDataSample GetLastDataSample()
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
