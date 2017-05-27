using System;
using JTSim;
using JMath;

namespace SolversTest
{
    class Program
    {
        static void Main(string[] args)
        {
            /*TestModel model = new TestModel(
                (double t) => (5d * t * Math.Sin(3d * t) * Math.Exp(-0.5d * t) + 4d),
                (double t, Vector<double> y) => (Vector<double>.Build.Dense(1, 5d * Math.Sin(3d * t) * Math.Exp(-t / 2d) + 15d * t * Math.Cos(3d * t) * Math.Exp(-t / 2d) - 0.5d * (5d * t * Math.Sin(3d * t) * Math.Exp(-t / 2d))))
                );*/
            TestModel model = new TestModel(
                            (double t) => (Math.Exp(0.5 * t * t + 1)),
                            (double t, JVector y) => (t * y)
                            );
            /*TestModel model = new TestModel(
                            (double t) => (2 + 2 * t + t * t - Math.Exp(t)),
                            (double t, JVector y) => (y - t*t)
                            );*/
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
            tester.Test(2.0, 0.001);

            Console.ReadKey();
        }
    }
}