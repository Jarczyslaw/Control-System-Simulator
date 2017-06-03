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
    public class ContinousFirstOrderExample : BaseModelExample
    {
        public override List<OpenLoopDataSample> GetSystemData()
        {
            ContinousFirstOrder model = new ContinousFirstOrder(2d, 3d);
            ContinousSystem system = new ContinousSystem(model, new SolverEuler(), new Vector(1, -1d));

            OpenLoop loop = new OpenLoop(system);
            Simulator.Step(loop, 15d);
            return loop.Data;
        }
    }
}
