using JTControlSystem.Solvers;

namespace JTControlSystem.Examples
{
    public class AdamsMoultonExample : BaseSolverExample
    {
        public override ISolver GetSolver()
        {
            return new SolverAdamsMoulton(5);
        }
    }
}
