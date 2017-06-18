using JTControlSystem.Solvers;

namespace JTControlSystemExamples
{
    public class EulerExample : BaseSolverExample
    {
        public override ISolver GetSolver()
        {
            return new SolverEuler();
        }
    }
}
