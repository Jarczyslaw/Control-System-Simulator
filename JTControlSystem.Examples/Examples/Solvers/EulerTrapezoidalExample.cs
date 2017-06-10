using JTControlSystem.Solvers;

namespace JTControlSystem.Examples
{
    public class EulerTrapezoidalExample : BaseSolverExample
    {
        public override ISolver GetSolver()
        {
            return new SolverEulerTrapezoidal();
        }
    }
}
