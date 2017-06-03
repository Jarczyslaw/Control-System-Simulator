using JTControlSystem;
using JTControlSystem.SignalGenerators;
using JTControlSystem.Solvers;
using JTControlSystem.Systems;
using JTControlSystem.Controllers;
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
            ContinousFirstOrder model = new ContinousFirstOrder(2d, 3d);
            ContinousSystem system = new ContinousSystem(model, new SolverEuler(), Vector.Ones(1));

            var controller = new P(3d);

            //OpenLoop loop = new OpenLoop(system, 0.1d);

            var loop = new ControlSystem(system, controller, 0.1d);
            loop.mode = ControlSystemMode.CloseLoop;

            for (int i = 0; i < 40; i++)
            {
                loop.NextIteration(2d);
                if (loop.CurrentTime >= 2d)
                    loop.mode = ControlSystemMode.OpenLoop;
            }
                

            FileWriter.ToFile(loop.Data, @"C://data.txt");

            Console.ReadKey();
        }
    }
}
