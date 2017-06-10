using JTControlSystem.Solvers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace SolversTest
{
    public class Launcher
    {
        private SolverWrapper[] wrappers;

        private DifferentialEquations differentialEquations;
        private ExactSolution exactSolution;

        public Launcher(DifferentialEquations differentialEquations, ExactSolution exactSolution, params ISolver[] solvers)
        {
            this.differentialEquations = differentialEquations;
            this.exactSolution = exactSolution;

            wrappers = new SolverWrapper[solvers.Length];
            for (int i = 0; i < wrappers.Length; i++)
                wrappers[i] = new SolverWrapper(solvers[i], differentialEquations);
        }

        public void Test(double time, double dt)
        {
            int iterations = (int)Math.Ceiling(time / dt);

            // initialize all wrappers
            double initialCondition = exactSolution(0d);
            foreach (var wrapper in wrappers)
                wrapper.Initialize(initialCondition, dt);

            // calculate reference data
            var referenceData = GetReferenceData(iterations, dt);

            // performs test on all wrappers and results
            List<SolverResults> results = new List<SolverResults>();
            foreach(var wrapper in wrappers)
            {
                var executionTime = ExecTime.Run(() =>
                {
                    PerformModelTest(wrapper, iterations, dt);
                });
                results.Add(new SolverResults(wrapper, referenceData, executionTime));
            }

            // sort results and show
            results.Sort((r1, r2) => (r1.Mse > r2.Mse) ? 1 : -1);
            foreach (var result in results)
                Console.WriteLine(result.ToString());
        }

        private void PerformModelTest(SolverWrapper model, int iterations, double dt)
        {
            for (int i = 1; i < iterations; i++)
            {
                double currentTime = i * dt;
                model.NextIteration(currentTime, dt);
            }
        }

        private List<DataSample> GetReferenceData(int iterations, double dt)
        {
            var referenceData = new List<DataSample>();
            for (int i = 0;i < iterations;i++)
            {
                double currentTime = i * dt;
                double exact = exactSolution(currentTime);
                referenceData.Add(new DataSample()
                {
                    time = currentTime,
                    value = exact
                });
            }
            return referenceData;
        }
    }
}
