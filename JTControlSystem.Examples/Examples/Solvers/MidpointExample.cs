using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JTControlSystem.Solvers;

namespace JTControlSystem.Examples
{
    public class MidpointExample : BaseSolverExample
    {
        public override ISolver GetSolver()
        {
            return new SolverMidpoint();
        }
    }
}
