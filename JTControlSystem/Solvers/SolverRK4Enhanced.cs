using System;
using JTControlSystem.Solvers;
using JTMath;

namespace JTControlSystem.Solvers
{
    public class SolverRK4Enhanced : ISolver
    {
        private double oneThirdStep;
        private double oneEightStep;

        public Vector Solve(DifferentialEquations differentialEquasions, Vector state, double input, double time, double dt)
        {
            Vector k1 = differentialEquasions(state, input, time);
            Vector k2 = differentialEquasions(state + oneThirdStep * k1, input, time + oneThirdStep);
            Vector k3 = differentialEquasions(state + (-oneThirdStep * k1 + dt * k2), input, time + 2d * oneThirdStep);
            Vector k4 = differentialEquasions(state + dt * (k1 - k2 + k3), input, time + dt);
            return state + oneEightStep * (k1 + 3f * k2 + 3f * k3 + k4);
        }

        public void Initialize(double dt)
        {
            oneEightStep = dt / 8d;
            oneThirdStep = dt / 3d;
        }
    }
}
