﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JTControlSystem.Solvers;

namespace JTControlSystemExamples
{
    public class RK4EnhancedExample : BaseSolverExample
    {
        public override ISolver GetSolver()
        {
            return new SolverRK4Enhanced();
        }
    }
}
