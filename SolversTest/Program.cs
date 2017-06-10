using System;
using JTMath;
using JTControlSystem.Solvers;

namespace SolversTest
{
    class Program
    {
        static void Main(string[] args)
        {
            DifferentialEquations differentialEquation = (state, input, time) => (time * state); // y' = t * y
            ExactSolution exactSolution = (time) => (Math.Exp(0.5 * time * time + 1));
            Launcher launcher = new Launcher(differentialEquation, exactSolution,
                new SolverEuler(),
                new SolverEulerTrapezoidal(),
                new SolverHeun(),
                new SolverMidpoint(),
                new SolverRK4(),
                new SolverRK4Enhanced(),
                new SolverDormandPrince(),
                new SolverAdamsBashforth(5),
                new SolverAdamsMoulton(5));

            launcher.Test(2d, 0.001d);

            Console.ReadKey();
        }
    }
}