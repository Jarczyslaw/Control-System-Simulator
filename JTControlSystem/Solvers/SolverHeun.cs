using System;
using JTControlSystem.Solvers;
using JTMath;

namespace JTControlSystem.Solvers
{
    public class SolverHeun : ISolver
    {
        private double halfStep;

        public void Initialize(double dt)
        {
            halfStep = 0.5d * dt;
        }

        public Vector Solve(DifferentialEquations differentialEquasions, Vector state, double input, double time, double dt)
        {
            Vector k1 = differentialEquasions(state, input, time);
            Vector k2 = differentialEquasions(state + dt * k1, input, time + dt);
            return state + halfStep * (k1 + k2);
        }
    }
}
