using JTMath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTControlSystem.Systems
{
    // Model in state space
    // x' = Ax + Bu
    // y = Cx + Du
    // model SISO - one input one output
    // wektors' sizes:
    // x [N,1], A [N,N], B [N,1], C [1,N], D [1,1], y [1,1]
    public class StateSpaceModel : IContinousModel
    {
        private Matrix A;
        private Matrix B;
        private Matrix C;
        private double D;

        public StateSpaceModel(Matrix A, Vector B, Vector C, double D)
        {
            this.A = A;
            this.B = new Matrix(B);
            this.C = new Matrix(C, false);
            this.D = D;
        }

        public int GetOrder
        {
            get
            {
                return A.Rows();
            }
        }

        public Vector DifferentialEquations(Vector state, double input, double time)
        {
            Matrix s = new Matrix(state);

            Matrix diff = A * s + B * input;
            return new Vector(diff);
        }

        public double OutputEquation(Vector state, double input)
        {
            Matrix s = new Matrix(state);

            Matrix output = C * s + D * input;
            return output[0,0];
        }
    }
}
