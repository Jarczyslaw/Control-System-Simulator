using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JTControlSystem.Systems;
using JTMath;
using JTControlSystem.Solvers;
using JTControlSystem.Models;

namespace JTControlSystemExamples
{
    public class ContinousSecondOrderExample : BaseModelExample
    {
        public override ISystem GetSystem()
        {
            ContinousSecondOrder model = new ContinousSecondOrder(2d, 1d, 2d);
            // initial state is set from lowest derivative order
            // x = -2, x' = -4 
            return new ContinousSystem(model, new SolverRK4(), new Vector(new double[] { -2d, -4d })); 
        }
    }
}
