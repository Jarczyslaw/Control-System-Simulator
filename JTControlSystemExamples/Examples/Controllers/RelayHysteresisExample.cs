using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JTControlSystem.Controllers;

namespace JTControlSystemExamples
{
    public class RelayHysteresisExample : BaseControllerExample
    {
        public override IController GetController()
        {
            return new Relay(0.25d, 1d, -0.25d, -1d);
        }
    }
}
