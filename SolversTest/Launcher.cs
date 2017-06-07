using JTControlSystem.Solvers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolversTest
{
    public class Launcher
    {
        private TestModel[] models;

        private DifferentialEquations differentialEquations;
        private ExactSolution exactSolution;

        private List<DataSample> referenceData;

        public Launcher(DifferentialEquations differentialEquations, ExactSolution exactSolution, params ISolver[] solvers)
        {
            this.differentialEquations = differentialEquations;
            this.exactSolution = exactSolution;

            models = new TestModel[solvers.Length];
            for (int i = 0; i < models.Length; i++)
                models[i] = new TestModel(solvers[i], differentialEquations);
        }

        public void Test(double time, double dt)
        {
            double initialCondition = exactSolution(0d);
            foreach (var model in models)
                model.Initialize(initialCondition, dt);

            int iterations = (int)Math.Ceiling(time / dt);
            foreach(var model in models)
            {
                for (int i = 1; i < iterations; i++)
                {
                    double currentTime = i * dt;
                    model.NextIteration(currentTime, dt);
                }
            }
        }

        private void GetReferenceData()
        {
            referenceData = new List<DataSample>();

        }
    }
}
