using JTControlSystem.Solvers;

namespace JTControlSystem.Examples
{
    public class EulerExample : BaseSolverExample
    {
        public override ISolver GetSolver()
        {
            return new SolverEuler();
        }
    }
}
