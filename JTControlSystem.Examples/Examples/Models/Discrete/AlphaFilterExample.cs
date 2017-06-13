using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JTControlSystem.Systems;
using JTMath;
using JTControlSystem.Models;

namespace JTControlSystem.Examples
{
    public class AlphaFilterExample : BaseModelExample
    {
        public override ISystem GetSystem()
        {
            var model = new AlphaFilter(2d, 3d);
            return new DiscreteSystem(model, new Vector(1, -1d));
        }
    }
}
