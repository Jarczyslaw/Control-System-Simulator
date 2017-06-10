using JTControlSystem.Solvers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolversTest
{
    public class SolverResults
    {
        private ISolver solver;
        private long executionTime;
        public double Mse { get; private set; }
        
        public SolverResults(SolverWrapper wrapper, List<DataSample> referenceSolution, long executionTime)
        {
            solver = wrapper.Solver;
            this.executionTime = executionTime;
            Mse = GetMse(wrapper.Data, referenceSolution);
        }

        private double GetMse(List<DataSample> solverResults, List<DataSample> reference)
        {
            double sum = 0d;
            for (int i = 0; i < solverResults.Count; i++)
                sum += Math.Pow(solverResults[i].value - reference[i].value, 2d);
            return sum / solverResults.Count;
        }

        public override string ToString()
        {
            return string.Format("{0}, execution time: {1:000}, mse: {2:E8}", solver.GetType().Name.PadLeft(25, ' '), executionTime, Mse);
        }
    }
}
