using JTControlSystem.Solvers;

namespace JTControlSystem.Examples
{
    public class AdamsBashforthExample : BaseSolverExample
    {
        public override ISolver GetSolver()
        {
            return new SolverAdamsBashforth(5);
        }
    }
}
