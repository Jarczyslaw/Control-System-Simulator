using JTMath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTControlSystem.Models
{
    // Model in state space
    // x' = Ax + Bu
    // y = Cx + Du
    // model SISO - one input one output
    // wektors' sizes:
    // x [N,1], A [N,N], B [N,1], C [1,N], D [1,1], y [1,1]
    // remember that initial state for state space applies for x (internal state) not for output
    public class StateSpaceModel : IContinousModel
    {
        public Matrix A { get; private set; }
        public Vector B { get; private set; }
        public Vector C { get; private set; }
        public double D { get; private set; }

        public StateSpaceModel(Matrix A, Vector B, Vector C, double D)
        {
            this.A = A;
            this.B = B;
            this.C = C;
            this.D = D;
        }

        public int GetOrder
        {
            get
            {
                return A.Rows;
            }
        }

        public Vector DifferentialEquations(Vector state, double input, double time)
        {
            Matrix s = new Matrix(state);
            Matrix b = new Matrix(B);
            Matrix diff = A * s + b * input;
            return new Vector(diff);
        }

        public double OutputEquation(Vector state, double input)
        {
            Matrix s = new Matrix(state);
            Matrix c = new Matrix(C, false);
            Matrix output = c * s + D * input;
            return output[0, 0];
        }
    }
}
