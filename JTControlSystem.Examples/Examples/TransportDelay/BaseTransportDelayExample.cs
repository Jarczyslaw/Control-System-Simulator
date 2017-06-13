using JTControlSystem.Models;
using JTControlSystem.SignalGenerators;
using JTControlSystem.Solvers;
using JTControlSystem.Systems;
using JTMath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTControlSystem.Examples
{
    public class BaseTransportDelayExample : IExample
    {
        private List<BareSystemDataSample> data;
        private double delay;

        public BaseTransportDelayExample(double delay)
        {
            this.delay = delay;
        }

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
            ContinousFirstOrder model = new ContinousFirstOrder(2d, 3d);
            ContinousSystem system = new ContinousSystem(model, new SolverRK4(), Vector.Zeros(1), delay);

            BareSystem loop = new BareSystem(system);
            Simulator.SignalSimulation(loop, 20d, new StepsGenerator(new double[] { 4d, 10d, 15d }, new double[] { 1d, 2d, 4d }));
            data = loop.Data;
        }
    }
}
