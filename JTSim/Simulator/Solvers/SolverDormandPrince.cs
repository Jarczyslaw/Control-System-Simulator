using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;

namespace JTSim
{
    public class SolverDormandPrince : ISolver
    {
        Vector<double> c = Vector<double>.Build.Dense(new double[] { 1d/5d, 3d/10d, 4d/5d, 8d/9d, 1d, 1d });
        Vector<double> b1 = Vector<double>.Build.Dense(new double[] { 35d/384d, 0d, 500d/1113d, 125d/192d, -2187d/6784d, 11d/84d, 0d});
        Vector<double> b2 = Vector<double>.Build.Dense(new double[] { 5179d/57600d, 0d, 7571d/16695d, 393d/640, -92097d/339200d, 187d/2100d, 1d/40d});
        Matrix<double> a = Matrix<double>.Build.Dense(6, 6, new double[] {
            1d/5d, 3d/40d, 44d/45d, 19372d/6561d, 9017d/3168d, 35d/384d,
            0d, 9d/40d, -56d/15d, -25360d/2187d, -355d/33d, 0d,
            0d, 0d, 32d/9d, 64448d/6561d, 46732d/5247d, 500d/1113d,
            0d, 0d, 0d, -212d/729d, 49d/176d, 125d/192d,
            0d, 0d, 0d, 0d, -5103d/18656d, -2187d/6784d,
            0d, 0d, 0d, 0d, 0d, 11d/84d
        });

        public Vector<double> Solve(ContinousModel model, Vector<double> state, double input, double t, double h)
        {
            Vector<double> k1 = h * model.DifferentialEquasions(state, input, t);
            Vector<double> k2 = h * model.DifferentialEquasions(state + a[0, 0] * k1, input, t + c[0]);
            Vector<double> k3 = h * model.DifferentialEquasions(state + a[1, 0] * k1 + a[1,1] * k2, input, t + c[1]);
            Vector<double> k4 = h * model.DifferentialEquasions(state + a[2, 0] * k1 + a[2, 1] * k2 + a[2, 2] * k3, input, t + c[2]);
            Vector<double> k5 = h * model.DifferentialEquasions(state + a[3, 0] * k1 + a[3, 1] * k2 + a[3, 2] * k3 + a[3,3] * k4, input, t + c[3]);
            Vector<double> k6 = h * model.DifferentialEquasions(state + a[4, 0] * k1 + a[4, 1] * k2 + a[4, 2] * k3 + a[4, 3] * k4 + a[4, 4] * k5, input, t + c[4]);
            Vector<double> k7 = h * model.DifferentialEquasions(state + a[5, 0] * k1 + a[5, 1] * k2 + a[5, 2] * k3 + a[5, 3] * k4 + a[5, 4] * k5 + a[5, 5] * k6, input, t + c[2]);
            return state + b1[0] * k1 + b1[1] * k2 + b1[2] * k3 + b1[3] * k4 + b1[4] * k5 + b1[5] * k6 + b1[6] * k7;
            //return state + b2[0] * k1 + b2[1] * k2 + b2[2] * k3 + b2[3] * k4 + b2[4] * k5 + b2[5] * k6 + b2[6] * k7;
        }
    }
}
