using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JTControlSystem.Controllers;

namespace JTControlSystem.Examples
{
    public class RelayExample : BaseControllerExample
    {
        public override IController GetController()
        {
            return new Relay(0d, 1d, 0d, -1d);
        }
    }
}
