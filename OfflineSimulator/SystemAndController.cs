using JTControlSystem.Controllers;
using JTControlSystem.Models;
using JTControlSystem.Solvers;
using JTControlSystem.Systems;
using JTMath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfflineSimulator
{
    public class SystemAndController
    {
        public static ISystem GetSystem()
        {
            var model = new ContinousSecondOrder(2d, 1d, 3d);
            return new ContinousSystem(model, new SolverRK4(), Vector.Zeros(2));
        }

        public static IController GetController()
        {
            return new P(3d);
        }
    }
}
