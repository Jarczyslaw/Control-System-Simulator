using System;
using JTMath;
using JTControlSystem.Solvers;

namespace SolversTest
{
    class Program
    {
        static void Main(string[] args)
        {
            /*TestModel model = new TestModel(
                            (double t) => (Math.Exp(0.5 * t * t + 1)),
                            (double t, Vector y) => (t * y)
                            );
            Tester tester = new Tester(model, new ISolver[] {
                new SolverEuler(),
                new SolverEulerTrapezoidal(),
                new SolverHeun(),
                new SolverMidPoint(),
                new SolverRK4(),
                new SolverRK4Enhanced(),
                new SolverDormandPrince(),
                new SolverAdamsBashforth(5),
                new SolverAdamsMoulton(5)
            });
            tester.Test(2.0, 0.001);*/

            DifferentialEquations differentialEquation = (state, input, time) => (time * state); // y' = t * y
            ExactSolution exactSolution = (time) => (Math.Exp(0.5 * time * time + 1));
            Launcher launcher = new Launcher(differentialEquation, exactSolution,
                new SolverEuler());

            launcher.Test(2d, 0.001d);

            Console.ReadKey();
        }
    }
}