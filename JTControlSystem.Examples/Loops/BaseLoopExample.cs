using JTControlSystem.Controllers;
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
    public class BaseLoopExample
    {
        protected IContinousModel model;
        protected ISystem system;
        protected IController controller;

        public BaseLoopExample()
        {
            model = new ContinousFirstOrder(4d, 3d);
            system = new ContinousSystem(model, new SolverEuler(), new Vector(1, -1d));
            controller = new P(10d);
        }
    }
}
