using JTControlSystem.Solvers;
using JTMath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolversTest
{
    public class TestModel
    {
        private ISolver solver;
        private DifferentialEquations differentialEquations;

        private Vector state;
        private List<DataSample> data;

        public TestModel(ISolver solver, DifferentialEquations differentialEquations)
        {
            this.solver = solver;
            this.differentialEquations = differentialEquations;
            data = new List<DataSample>();
        }

        public void NextIteration(double time, double dt)
        {
            state = solver.Solve(differentialEquations, state, 0d, time - dt, dt);
            data.Add(new DataSample()
            {
                time = time,
                value = state[0]
            });
        }

        public void Initialize(double initialValue, double dt)
        {
            solver.Initialize(dt);
            state = new Vector(1, initialValue);
            data.Clear();
            data.Add(new DataSample()
            {
                time = 0d,
                value = state[0]
            });
        }
    }
}
