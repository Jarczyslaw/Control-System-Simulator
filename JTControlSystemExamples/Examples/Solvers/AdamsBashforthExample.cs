using JTControlSystem.Solvers;

namespace JTControlSystemExamples
{
    public class AdamsBashforthExample : BaseSolverExample
    {
        public override ISolver GetSolver()
        {
            return new SolverAdamsBashforth(5);
        }
    }
}
