﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JVectors;

namespace JTSim
{
    public class Test : ContinousModel
    {
        public Test()
        {
            initState = new JVector(1, 0d);
        }

        public override JVector DifferentialEquasions(JVector state, double input, double t)
        {
            return new JVector(1, t);
        }

        public override double OutputEquation(JVector state, double input)
        {
            return state[0];
        }
    }
}
