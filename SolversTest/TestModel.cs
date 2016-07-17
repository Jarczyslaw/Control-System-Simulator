using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JTSim;
using JVectors;

namespace SolversTest
{
    public class TestModel : ContinousModel
    {
        Func<double, double> function;
        Func<double, JVector, JVector> differential;

        public TestModel(Func<double, double> function, Func<double, JVector, JVector> differential)
        {
            this.function = function;
            this.differential = differential;
            initState = new JVector(1, ExactSolution(0.0));
        }

        public override JVector DifferentialEquasions(JVector state, double input, double t)
        {
            JVector diff = differential(t, state);
            return diff;
        }

        public override double OutputEquation(JVector state, double input) { return 0.0; }

        public double ExactSolution(double t)
        {
            return function(t);
        }
    }
}
