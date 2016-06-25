using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JTSim;
using MathNet.Numerics.LinearAlgebra;

namespace SolversTest
{
    public class TestSystem
    {
        private TestModel model;
        private Vector<float> state;

        public TestSystem(TestModel model)
        {
            this.model = model;
        }

        public float Step(ISolver solver, float t, float h)
        {
            state = solver.Solve(model, state, 0f, t, h);
            return state[0];
        }

        public float Init()
        {
            state = model.initState.Clone();
            return state[0];
        }
    }
}
