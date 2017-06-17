using JTControlSystem.Models;
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
            ContinousSecondOrder model = new ContinousSecondOrder(2d, 1d, 1d);
            var system = new ContinousSystem(model, GetSolver(), new Vector(new double[] { -1d, -4d }));

            BareSystem loop = new BareSystem(system);
            Simulator.Step(loop, 20d, 0.1d);
            data = loop.Data;
        }

        public abstract ISolver GetSolver();
    }
}
