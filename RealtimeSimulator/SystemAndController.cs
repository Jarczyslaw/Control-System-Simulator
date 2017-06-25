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

namespace RealtimeSimulator
{
    public class SystemAndController
    {
        public static ISystem GetSystem()
        {
            var model = new ContinousSecondOrder(3d, 1d, 2d);
            return new ContinousSystem(model, new SolverRK4(), Vector.Zeros(2));
        }

        public static IController GetController()
        {
            return new PID(3.1663d, 2.7337d, 0.4104d);
        }
    }
}
