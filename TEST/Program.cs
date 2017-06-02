using JTControlSystem;
using JTControlSystem.SignalGenerators;
using JTControlSystem.Solvers;
using JTControlSystem.Systems;
using JTMath;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST
{
    class Program
    {
        static void Main(string[] args)
        {
            //ContinousFirstOrder model = new ContinousFirstOrder(2d, 3d);
            //ContinousSystem system = new ContinousSystem(model, new SolverEuler(), Vector.Ones(1));


            OpenLoop loop = new OpenLoop(system, 0.1d);

            for (int i = 0; i < 101; i++)
                loop.NextIteration(2d);

            FileWriter.ToFile(loop.Data, @"C://data.txt");

            Console.ReadKey();
        }
    }
}
