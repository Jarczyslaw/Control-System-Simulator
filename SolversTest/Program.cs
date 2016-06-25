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
                new SolverRK4()
            });
            tester.Test(10f, 0.01f);
        }
    }
}
