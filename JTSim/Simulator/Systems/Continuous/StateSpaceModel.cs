using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JVectors;

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
        private JVector B;
        private JVector C;
        private double D;

        public StateSpaceModel(JMatrix A, JVector B, JVector C, double D,
            JVector initState)
        {
            this.A = A;
            this.B = B;
            this.C = C;
            this.D = D;

            this.initState = initState;
        }

        public override JVector DifferentialEquasions(JVector state, double input, double t)
        {
            JVector diff = A * state + B * input;
            return diff;
        }

        public override double OutputEquation(JVector state, double input)
        {
            // wektory nie maja drugiego wymiaru wiec zeby przemnozyc wektor 1xN oraz Nx1 trzeba przemnozyc wszystkie elementy a potem jest zsumowac
            double v = (C * state).Sum() + D * input;
            return v;
        }
    }
}
