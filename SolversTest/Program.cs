using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JTSim;

namespace SolversTest
{
    class Program
    {
        static void Main(string[] args)
        {
            TestModel model = new TestModel(
                (double t) => (5d * t * Math.Sin(3d * t) * Math.Exp(-0.5d * t) + 4d),
                (double t) => (5d * Math.Sin(3d * t) * Math.Exp(-t / 2d) + 15d * t * Math.Cos(3d * t) * Math.Exp(-t / 2d) - 0.5d * (5d * t * Math.Sin(3d * t) * Math.Exp(-t / 2d)))
                );
            Tester tester = new Tester(model, new ISolver[] {
                new SolverEuler(),
                new SolverMidPoint(),
                new SolverRK4(),
                new SolverRK4Enhanced(),
                new SolverDormandPrince(),
            });
            tester.Test(100d, 0.001d);

            Console.ReadKey();
        }
    }
}
