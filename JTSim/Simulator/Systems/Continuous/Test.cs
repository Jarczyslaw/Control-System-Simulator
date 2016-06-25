using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;

namespace JTSim
{
    public class Test : ContinousModel
    {
        public Test()
        {
            initState = Vector<double>.Build.Dense(1, 0d);
        }

        public override Vector<double> DifferentialEquasions(Vector<double> state, double input, double t)
        {
            return Vector<double>.Build.Dense(1, t);
        }

        public override double OutputEquation(Vector<double> state, double input)
        {
            return state[0];
        }
    }
}
