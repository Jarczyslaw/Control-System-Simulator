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
    public class CloseLoop : ILoop
    {
        public List<CloseLoopDataSample> Data { get; private set; }

        private CloseLoopScheme scheme;

        #region CONSTRUCTORS

        public CloseLoop() : this(new TransparentSystem(), new TransparentController()) { }

        public CloseLoop(ISystem system) : this(system, new TransparentController()) { }

        public CloseLoop(IController controller) : this(new TransparentSystem(), controller) { }

        public CloseLoop(ISystem system, IController controller)
        {
            scheme = new CloseLoopScheme(system, controller);
            Data = new List<CloseLoopDataSample>();
        }

        #endregion

        public void NextIteration(double input, double time, double dt)
        {
            double previousSystemOutput = Data.Last().systemOutput;
            var dataSample = scheme.NextIteration(input, previousSystemOutput, time, dt);
            Data.Add(dataSample);
        }

        public CloseLoopDataSample GetLastDataSample()
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
