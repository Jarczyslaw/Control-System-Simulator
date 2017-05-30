using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JTMath;

namespace JTControlSystem.Solvers
{
    public class SolverEuler : ISolver
    {
        public Vector Solve(DifferentialEquations differentialEquasions, Vector state, double input, double time, double dt)
        {
            Vector differentials = differentialEquasions(state, input, time);
            return state + dt * differentials;
        }

        public void Initialize(double dt) { }
    }
}
