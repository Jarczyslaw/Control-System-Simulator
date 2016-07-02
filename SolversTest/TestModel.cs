﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JTSim;
using MathNet.Numerics.LinearAlgebra;

namespace SolversTest
{
    public class TestModel : ContinousModel
    {
        Func<double, double> function;
        Func<double, Vector<double>, Vector<double>> differential;

        public TestModel(Func<double, double> function, Func<double, Vector<double>, Vector<double>> differential)
        {
            this.function = function;
            this.differential = differential;
            initState = Vector<double>.Build.Dense(1, ExactSolution(0f));
        }

        public override Vector<double> DifferentialEquasions(Vector<double> state, double input, double t)
        {
            Vector<double> diff = differential(t, state);
            return diff;
        }

        public override double OutputEquation(Vector<double> state, double input) { return 0; }

        public double ExactSolution(double t)
        {
            return function(t);
        }
    }
}
