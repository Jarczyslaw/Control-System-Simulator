using JTMath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTControlSystem.Solvers
{
    public interface ISolver
    {
        Vector Solve(DifferentialEquations differentialEquasions, Vector state, double input, double time, double dt);
        void Initialize(double dt);
    }
}
