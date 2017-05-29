using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JTControlSystem;
using JTMath;

namespace SolversTest
{
    public class TestModel : ContinousModel
    {
        Func<double, double> function;
        Func<double, Vector, Vector> differential;

        public TestModel(Func<double, double> function, Func<double, Vector, Vector> differential)
        {
            this.function = function;
            this.differential = differential;
            initState = new Vector(1, ExactSolution(0.0));
        }

        public override Vector DifferentialEquations(Vector state, double input, double t)
        {
            Vector diff = differential(t, state);
            return diff;
        }

        public override double OutputEquation(Vector state, double input) { return 0.0; }

        public double ExactSolution(double t)
        {
            return function(t);
        }
    }
}
