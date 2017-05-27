using JMath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTSim
{
    // model w przestrzeni stanow
    // x' = Ax + Bu
    // y = Cx + Du
    // model SISO - jedno wejscie i jedno wyjscie
    // wymiary wektorow:
    // x [N,1], A [N,N], B [N,1], C [1,N], D [1,1], y [1,1]
    public class StateSpaceModel : ContinousModel
    {
        private JMatrix A;
        private JMatrix B;
        private JMatrix C;
        private double D;

        public StateSpaceModel(JMatrix A, JVector B, JVector C, double D,
            JVector initState)
        {
            this.A = A;
            this.B = new JMatrix(B);
            this.C = new JMatrix(C, false);
            this.D = D;

            this.initState = initState;
        }

        public override JVector DifferentialEquations(JVector state, double input, double t)
        {
            JMatrix s = new JMatrix(state);

            JMatrix diff = A * s + B * input;
            return new JVector(diff);
        }

        public override double OutputEquation(JVector state, double input)
        {
            JMatrix s = new JMatrix(state);

            JMatrix output = C * s + D * input;
            return output[0,0];
        }
    }
}
