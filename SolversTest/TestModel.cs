using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JTSim;
using MathNet.Numerics.LinearAlgebra;

namespace SolversTest
{
    public class TestModel : ContinousModel
    {
        public TestModel()
        {
            this.initState = Vector<double>.Build.Dense(1, ExactSolution(0f));
        }

        public override Vector<double> DifferentialEquasions(Vector<double> state, double input, double t)
        {
            double x = 5d * Math.Sin(3d * t) * Math.Exp(-t / 2d) + 15d * t * Math.Cos(3d * t) * Math.Exp(-t / 2d) - 0.5d * (5d * t * Math.Sin(3d * t) * Math.Exp(-t / 2d));
            return Vector<double>.Build.Dense(1, x);
        }

        public override double OutputEquation(Vector<double> state, double input)
        {
            return state[0];
        }

        public double ExactSolution(double t)
        {
            return 5d * t * Math.Sin(3d * t) * Math.Exp(-0.5d * t) + 4d;
        }
    }
}
