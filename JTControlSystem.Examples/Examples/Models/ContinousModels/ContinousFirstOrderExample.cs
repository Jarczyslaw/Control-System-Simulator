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
    public class ContinousFirstOrderExample : BaseModelExample
    {
        public override ISystem GetSystem()
        {
            ContinousFirstOrder model = new ContinousFirstOrder(2d, 3d);
            return new ContinousSystem(model, new SolverRK4(), new Vector(1, -2d));
        }
    }
}
