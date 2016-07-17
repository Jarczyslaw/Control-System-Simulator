﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JVectors;

namespace JTSim
{
    public class TransferFunction : ContinousModel
    {
        private StateSpaceModel stateSpace;

        public TransferFunction(double[] num, double[] den)
        {
            if (num.Length >= den.Length)
                throw new Exception("Numerator must have lower order than denominator");

            ToStateSpace(num, den);
        }

        public override JVector DifferentialEquasions(JVector state, double input, double t)
        {
            return stateSpace.DifferentialEquasions(state, input, t);
        }

        public override double OutputEquation(JVector state, double input)
        {
            return stateSpace.OutputEquation(state, input);
        }

        private void ToStateSpace(double[] num, double[] den)
        {
            // convert tf function to controllable canonical state space representation
            // K(s) = (s + 3) / (s^3 + 2s + s + 1)
            // A = [0, 1, 0; 0, 0, 1; -1, -1, -2]
            // B = [0;0;1]
            // C = [3,1,0]
            // D = 0
            double a = den[0];
            for (int i = 0; i < num.Length; i++)
                num[i] = num[i] / a;
            for (int i = 0; i < den.Length; i++)
                den[i] = den[i] / a;

            int len = den.Length - 1;
            JMatrix A = new JMatrix(len, len, 0.0);
            for (int i = 0;i < len;i++)
                A[len - 1, i] = -den[den.Length - 1 - i];
            int ones = len - 1;
            for (int i = 0; i < ones; i++)
                A[i, i + 1] = 1.0;
            JVector B = new JVector(len, 0.0);
            B[len - 1] = 1.0;
            JVector C = new JVector(len, 0.0);
            for (int i = num.Length - 1; i >= 0; i--)
                C[num.Length - 1 - i] = num[i];
            double D = 0.0;

            initState = new JVector(len, 0.0);
            stateSpace = new StateSpaceModel(A, B, C, D, null);
        }
    }
}
