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
            Tester tester = new Tester(new TestModel(), new ISolver[] {
                new SolverEuler(),
                new SolverMidPoint(),
                new SolverRK4(),
                new SolverRK4Enhanced(),
                new SolverDormandPrince(),
            });
            tester.Test(10d, 0.01d);

            Console.ReadKey();
        }
    }
}
