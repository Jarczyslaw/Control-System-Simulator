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
        private ISystem system;

        public OpenLoop() : this(new TransparentSystem(), Consts.defaultTimeStep) { }

        public OpenLoop(ISystem system) : this(system, Consts.defaultTimeStep) { }

        public OpenLoop(ISystem system, double dt)
        {
            this.system = system;
            this.dt = dt;
            Data = new List<OpenLoopDataSample>();
        }

        public OpenLoopDataSample NextIteration(double input)
        {
            iteration++;
            double systemOutput;
            if (iteration == 0)
                systemOutput = system.Initialize(dt);
            else
                systemOutput = system.NextIteration(input, CurrentTime - dt, dt);
            OpenLoopDataSample dataSample = new OpenLoopDataSample()
            {
                time = CurrentTime,
                input = input,
                output = systemOutput
            };
            Data.Add(dataSample);
            return dataSample;
        }

        public override void Initialize()
        {
            base.Initialize();
            Data.Clear();
        }
    }
}
