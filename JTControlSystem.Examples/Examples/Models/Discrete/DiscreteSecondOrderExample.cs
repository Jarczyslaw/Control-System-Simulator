using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JTControlSystem.Systems;
using JTMath;
using JTControlSystem.Models.Discrete;

namespace JTControlSystem.Examples
{
    public class DiscreteSecondOrderExample : BaseModelExample
    {
        public override ISystem GetSystem()
        {
            var model = new DiscreteSecondOrder(2d, 1d, 3d);
            return new DiscreteSystem(model, new Vector(new double[] { 0d, 0d }));
        }
    }
}
