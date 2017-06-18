using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JTControlSystem.Systems;
using JTControlSystem.Models;
using JTMath;

namespace JTControlSystemExamples
{
    public class DiscreteFirstOrderExample : BaseModelExample
    {
        public override ISystem GetSystem()
        {
            var model = new DiscreteFirstOrder(2d, 3d);
            return new DiscreteSystem(model, new Vector(1, -1d));
        }
    }
}
