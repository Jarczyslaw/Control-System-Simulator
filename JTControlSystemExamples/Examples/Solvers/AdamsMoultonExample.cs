using JTControlSystem.Solvers;

namespace JTControlSystemExamples
{
    public class AdamsMoultonExample : BaseSolverExample
    {
        public override ISolver GetSolver()
        {
            return new SolverAdamsMoulton(5);
        }
    }
}
