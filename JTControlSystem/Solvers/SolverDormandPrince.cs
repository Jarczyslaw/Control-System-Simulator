using System;
using JTControlSystem.Solvers;
using JTMath;

namespace JTControlSystem.Solvers
{
    public class SolverDormandPrince : ISolver
    {
        double[] c = new double[] { 1d / 5d, 3d / 10d, 4d / 5d, 8d / 9d, 1d, 1d };
        double[] b1 = new double[] { 35d / 384d, 0d, 500d / 1113d, 125d / 192d, -2187d / 6784d, 11d / 84d, 0d };
        double[] b2 = new double[] { 5179d / 57600d, 0d, 7571d / 16695d, 393d / 640d, -92097d / 339200d, 187d / 2100d, 1d / 40d };
        double[] a2 = new double[] { 1d / 5d };
        double[] a3 = new double[] { 3d / 40d, 9d / 40d };
        double[] a4 = new double[] { 44d / 45d, -56d / 15d, 32d / 9d };
        double[] a5 = new double[] { 19372d / 6561d, -25360d / 2187d, 64448d / 6561d, -212d / 729d };
        double[] a6 = new double[] { 9017d / 3168d, -355d / 33d, 46732d / 5247d, 49d / 176d, -5103d / 18656d };
        double[] a7 = new double[] { 35d / 384d, 0d, 500d / 1113d, 125d / 192d, -2187d / 6784d, 11d / 84d };

        public Vector Solve(DifferentialEquations differentialEquasions, Vector state, double input, double time, double dt)
        {
            Vector k1 = dt * differentialEquasions(state, input, time);
            Vector k2 = dt * differentialEquasions(state + a2[0] * k1, input, time + c[0] * dt);
            Vector k3 = dt * differentialEquasions(state + a3[0] * k1 + a3[1] * k2, input, time + c[1] * dt);
            Vector k4 = dt * differentialEquasions(state + a4[0] * k1 + a4[1] * k2 + a4[2] * k3, input, time + c[2] * dt);
            Vector k5 = dt * differentialEquasions(state + a5[0] * k1 + a5[1] * k2 + a5[2] * k3 + a5[3] * k4, input, time + c[3] * dt);
            Vector k6 = dt * differentialEquasions(state + a6[0] * k1 + a6[1] * k2 + a6[2] * k3 + a6[3] * k4 + a6[4] * k5, input, time + c[4] * dt);
            Vector k7 = dt * differentialEquasions(state + a7[0] * k1 + a7[1] * k2 + a7[2] * k3 + a7[3] * k4 + a7[4] * k5 + a7[5] * k6, input, time + c[5] * dt);
            //return state + b1[0] * k1 + b1[1] * k2 + b1[2] * k3 + b1[3] * k4 + b1[4] * k5 + b1[5] * k6 + b1[6] * k7;
            return state + b2[0] * k1 + b2[1] * k2 + b2[2] * k3 + b2[3] * k4 + b2[4] * k5 + b2[5] * k6 + b2[6] * k7;
        }

        public void Initialize(double dt) { }
    }
}
