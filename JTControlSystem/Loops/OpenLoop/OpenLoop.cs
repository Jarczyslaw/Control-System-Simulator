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
    public class OpenLoop : ILoop
    {
        public List<OpenLoopDataSample> Data { get; private set; }

        private OpenLoopScheme scheme;

        #region CONSTRUCTORS

        public OpenLoop() : this(new TransparentSystem(), new TransparentController()) { }

        public OpenLoop(ISystem system) : this(system, new TransparentController()) { }

        public OpenLoop(IController controller) : this(new TransparentSystem(), controller) { }

        public OpenLoop(ISystem system, IController controller)
        {
            scheme = new OpenLoopScheme(system, controller);
            Data = new List<OpenLoopDataSample>();
        }

        #endregion

        public void NextIteration(double input, double time, double dt)
        {
            var dataSample = scheme.NextIteration(input, time, dt);
            Data.Add(dataSample);
        }

        public OpenLoopDataSample GetLastDataSample()
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
