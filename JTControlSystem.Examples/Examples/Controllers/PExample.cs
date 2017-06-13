using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JTControlSystem.Controllers;

namespace JTControlSystem.Examples
{
    public class PExample : BaseControllerExample
    {
        public override IController GetController()
        {
            return new P(3d);
        }
    }
}
