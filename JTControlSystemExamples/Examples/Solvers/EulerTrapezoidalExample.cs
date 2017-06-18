using JTControlSystem.Solvers;

namespace JTControlSystemExamples
{
    public class EulerTrapezoidalExample : BaseSolverExample
    {
        public override ISolver GetSolver()
        {
            return new SolverEulerTrapezoidal();
        }
    }
}
