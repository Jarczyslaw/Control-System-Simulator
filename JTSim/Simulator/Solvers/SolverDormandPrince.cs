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
        Vector<float> c = Vector<float>.Build.Dense(new float[] { 1f/5f, 3f/10f, 4f/5f, 8f/9f, 1f, 1f });
        Vector<float> b1 = Vector<float>.Build.Dense(new float[] { 35f/384f, 0f, 500f/1113f, 125f/192f, -2187f/6784f, 11f/84f, 0f});
        Vector<float> b2 = Vector<float>.Build.Dense(new float[] { 5179f/57600f, 0f, 7571f/16695f, 393f/640, -92097f/339200f, 187f/2100f, 1f/40f});
        Matrix<float> a = Matrix<float>.Build.Dense(6, 6, new float[] {
            1f/5f, 3f/40f, 44f/45f, 19372f/6561f, 9017f/3168f, 35f/384f,
            0f, 9f/40f, -56f/15f, -25360f/2187f, -355f/33f, 0f,
            0f, 0f, 32f/9f, 64448f/6561f, 46732f/5247f, 500f/1113f,
            0f, 0f, 0f, -212f/729f, 49f/176f, 125f/192f,
            0f, 0f, 0f, 0f, -5103f/18656f, -2187f/6784f,
            0f, 0f, 0f, 0f, 0f, 11f/84f
        });

        public Vector<float> Solve(ContinousModel model, Vector<float> state, float input, float t, float h)
        {
            Vector<float> k1 = h * model.DifferentialEquasions(state, input, t);
            Vector<float> k2 = h * model.DifferentialEquasions(state + a[0, 0] * k1, input, t + c[0]);
            Vector<float> k3 = h * model.DifferentialEquasions(state + a[1, 0] * k1 + a[1,1] * k2, input, t + c[1]);
            Vector<float> k4 = h * model.DifferentialEquasions(state + a[2, 0] * k1 + a[2, 1] * k2 + a[2, 2] * k3, input, t + c[2]);
            Vector<float> k5 = h * model.DifferentialEquasions(state + a[3, 0] * k1 + a[3, 1] * k2 + a[3, 2] * k3 + a[3,3] * k4, input, t + c[3]);
            Vector<float> k6 = h * model.DifferentialEquasions(state + a[4, 0] * k1 + a[4, 1] * k2 + a[4, 2] * k3 + a[4, 3] * k4 + a[4, 4] * k5, input, t + c[4]);
            Vector<float> k7 = h * model.DifferentialEquasions(state + a[5, 0] * k1 + a[5, 1] * k2 + a[5, 2] * k3 + a[5, 3] * k4 + a[5, 4] * k5 + a[5, 5] * k6, input, t + c[2]);
            //return state + b1[0] * k1 + b1[1] * k2 + b1[2] * k3 + b1[3] * k4 + b1[4] * k5 + b1[5] * k6 + b1[6] * k7;
            return state + b2[0] * k1 + b2[1] * k2 + b2[2] * k3 + b2[3] * k4 + b2[4] * k5 + b2[5] * k6 + b2[6] * k7;
        }
    }
}
