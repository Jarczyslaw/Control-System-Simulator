using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JTControlSystem.Controllers;

namespace JTControlSystemExamples
{
    public class PIDExample : BaseControllerExample
    {
        public override IController GetController()
        {
            return new PID(3d, 2d, 0.5d);
        }
    }
}
