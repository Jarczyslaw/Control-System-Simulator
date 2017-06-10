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
    public abstract class BaseSolverExample : IExample
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
            TransferFunction model = new TransferFunction(new double[] { 2d, 1d }, new double[] { 2d, 0.5d, 1d });
            var system = new ContinousSystem(model, GetSolver(), new Vector(2, 0d));

            BareSystem loop = new BareSystem(system, 0.1d);
            Simulator.Step(loop, 20d);
            data = loop.Data;
        }

        public abstract ISolver GetSolver();
    }
}
