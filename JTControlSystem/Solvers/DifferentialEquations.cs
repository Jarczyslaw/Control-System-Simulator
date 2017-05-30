using JTMath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTControlSystem.Solvers
{
    public delegate Vector DifferentialEquations(Vector state, double input, double time);
}
