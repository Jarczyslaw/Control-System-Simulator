﻿using JTControlSystem.Controllers;
using JTControlSystem.Models;
using JTControlSystem.Solvers;
using JTControlSystem.Systems;
using JTMath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTControlSystem.Examples
{
    public abstract class BaseControllerExample : IExample
    {
        private List<CloseLoopDataSample> data;

        public double[] GetTime()
        {
            return data.Select(d => d.time).ToArray();
        }

        public double[] GetValues()
        {
            return data.Select(d => d.systemOutput).ToArray();
        }

        public void Run()
        {
            ContinousSecondOrder model = new ContinousSecondOrder(2d, 1d, 3d);
            ContinousSystem system = new ContinousSystem(model, new SolverRK4(), Vector.Zeros(2));

            CloseLoop loop = new CloseLoop(system, GetController(), 0.01d);
            Simulator.Step(loop, 20d);
            data = loop.Data;
        }

        public abstract  IController GetController(); 
    }
}