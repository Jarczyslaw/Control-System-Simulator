using JMath;

namespace JTSim
{
    public class SolverRK4 : ISolver
    {
        private double oneSixStep;
        private double halfStep;

        public JVector Solve(ContinousModel model, JVector state, double input, double t, double h)
        {
            JVector k1 = model.DifferentialEquations(state, input, t);
            JVector k2 = model.DifferentialEquations(state + halfStep * k1, input, t + halfStep);
            JVector k3 = model.DifferentialEquations(state + halfStep * k2, input, t + halfStep);
            JVector k4 = model.DifferentialEquations(state + h * k3, input, t + h);
            JVector diff = oneSixStep * (k1 + 2d * k2 + 2d * k3 + k4);
            return state + diff;
        }

        public void Init(double h)
        {
            oneSixStep = 1.0d / 6.0d * h;
            halfStep = 0.5d * h;
        }
    }
}
