using JTControlSystem.Solvers;
using JTMath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolversTest
{
    public class SolverWrapper
    {
        public ISolver Solver { get; private set; }
        private DifferentialEquations differentialEquations;

        private Vector state;
        public List<DataSample> Data { get; private set; }

        public SolverWrapper(ISolver solver, DifferentialEquations differentialEquations)
        {
            this.Solver = solver;
            this.differentialEquations = differentialEquations;
            Data = new List<DataSample>();
        }

        public void NextIteration(double time, double dt)
        {
            state = Solver.Solve(differentialEquations, state, 0d, time - dt, dt);
            Data.Add(new DataSample()
            {
                time = time,
                value = state[0]
            });
        }

        public void Initialize(double initialValue, double dt)
        {
            Solver.Initialize(dt);
            state = new Vector(1, initialValue);
            Data.Clear();
            Data.Add(new DataSample()
            {
                time = 0d,
                value = state[0]
            });
        }
    }
}
