using JTControlSystem.Solvers;

namespace JTControlSystem.Examples
{
    public class DormandPrinceExample : BaseSolverExample
    {
        public override ISolver GetSolver()
        {
            return new SolverDormandPrince();
        }
    }
}
