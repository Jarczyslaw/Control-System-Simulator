using JTControlSystem.Solvers;

namespace JTControlSystemExamples
{
    public class DormandPrinceExample : BaseSolverExample
    {
        public override ISolver GetSolver()
        {
            return new SolverDormandPrince();
        }
    }
}
