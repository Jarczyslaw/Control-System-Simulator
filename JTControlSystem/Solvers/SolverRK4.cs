using JTControlSystem.Solvers;
using JTMath;

namespace JTControlSystem.Solvers
{
    public class SolverRK4 : ISolver
    {
        private double oneSixStep;
        private double halfStep;

        public Vector Solve(DifferentialEquations differentialEquasions, Vector state, double input, double time, double dt)
        {
            Vector k1 = differentialEquasions(state, input, time);
            Vector k2 = differentialEquasions(state + halfStep * k1, input, time + halfStep);
            Vector k3 = differentialEquasions(state + halfStep * k2, input, time + halfStep);
            Vector k4 = differentialEquasions(state + dt * k3, input, time + dt);
            Vector diff = oneSixStep * (k1 + 2d * k2 + 2d * k3 + k4);
            return state + diff;
        }

        public void Initialize(double dt)
        {
            oneSixStep = 1.0d / 6.0d * dt;
            halfStep = 0.5d * dt;
        }
    }
}
