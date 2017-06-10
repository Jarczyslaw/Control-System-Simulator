using JTControlSystem.Solvers;
using JTMath;

namespace JTControlSystem.Solvers
{
    public class SolverMidpoint : ISolver
    {
        private double halfStep;

        public Vector Solve(DifferentialEquations differentialEquasions, Vector state, double input, double time, double dt)
        {
            Vector k1 = differentialEquasions(state, input, time);
            Vector k2 = differentialEquasions(state + halfStep * k1, input, time + halfStep);
            return state + dt * k2;
        }

        public void Initialize(double dt)
        {
            halfStep = 0.5d * dt;
        }
    }
}
