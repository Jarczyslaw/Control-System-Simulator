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
            this.initState = Vector<float>.Build.Dense(1, ExactSolution(0f));
        }

        public override Vector<float> DifferentialEquasions(Vector<float> state, float input, float t)
        {
            float x = 5f * (float)Math.Sin(3f * t) * (float)Math.Exp(-t / 2f) + 15f * t * (float)Math.Cos(3f * t) * (float)Math.Exp(-t / 2f) - 0.5f * (5f * t * (float)Math.Sin(3f * t) * (float)Math.Exp(-t / 2f));
            return Vector<float>.Build.Dense(1, x);
        }

        public override float OutputEquation(Vector<float> state, float input)
        {
            return state[0];
        }

        public float ExactSolution(float t)
        {
            return 5f * t * (float)Math.Sin(3f * t) * (float)Math.Exp(-0.5f * t) + 4;
        }
    }
}
