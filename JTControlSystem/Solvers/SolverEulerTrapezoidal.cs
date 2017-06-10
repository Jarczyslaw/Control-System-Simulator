using System;
using JTControlSystem.Solvers;
using JTMath;

namespace JTControlSystem.Solvers
{
    public class SolverEulerTrapezoidal : ISolver
    {
        private double halfStep;

        public void Initialize(double dt)
        {
            halfStep = 0.5 * dt;
        }

        public Vector Solve(DifferentialEquations differentialEquasions, Vector state, double input, double time, double dt)
        {
            Vector diffs = differentialEquasions(state, input, time);
            Vector prediction = state + dt * diffs;
            return state + halfStep * (diffs + differentialEquasions(prediction, input, time + dt)); // trapezoidal rule
        }
    }
}
