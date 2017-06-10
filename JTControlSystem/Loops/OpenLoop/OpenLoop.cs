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
    public class OpenLoop : BaseLoop
    {
        public List<OpenLoopDataSample> Data { get; private set; }

        private OpenLoopScheme scheme;

        #region CONSTRUCTORS

        public OpenLoop() : 
            this(new TransparentSystem(), new TransparentController(), Consts.defaultTimeStep) { }

        public OpenLoop(ISystem system) : 
            this(system, new TransparentController(), Consts.defaultTimeStep) { }

        public OpenLoop(ISystem system, double dt) : 
            this(system, new TransparentController(), dt) { }

        public OpenLoop(IController controller) : 
            this(new TransparentSystem(), controller, Consts.defaultTimeStep) { }

        public OpenLoop(IController controller, double dt) : 
            this(new TransparentSystem(), controller, dt) { }

        public OpenLoop(ISystem system, IController controller) : 
            this(system, controller, Consts.defaultTimeStep) { }

        public OpenLoop(ISystem system, IController controller, double dt)
        {
            this.Dt = dt;
            scheme = new OpenLoopScheme(system, controller);
            Data = new List<OpenLoopDataSample>();
            Initialize();
        }

        #endregion

        public override void NextIteration(double input)
        {
            iteration++;
            var dataSample = scheme.NextIteration(input, CurrentTime, Dt);
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
            var initialData = scheme.Initialize(CurrentTime, Dt);
            Data.Add(initialData);
        }
    }
}
