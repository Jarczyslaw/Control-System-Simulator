using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;

namespace JTSim
{
    public class SolverMidPoint : ISolver
    {
        private double halfStep;

        public Vector<double> Solve(ContinousModel model, Vector<double> state, double input, double t, double h)
        {
            Vector<double> k1 = model.DifferentialEquasions(state, input, t);
            Vector<double> k2 = model.DifferentialEquasions(state + halfStep * k1, input, t + halfStep);
            return state + halfStep * (k1 + k2);
        }

        public void Init(double h)
        {
            halfStep = 0.5d * h;
        }
    }
}
