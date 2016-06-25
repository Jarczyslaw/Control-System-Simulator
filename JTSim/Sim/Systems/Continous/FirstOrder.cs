using System;
using MathNet.Numerics.LinearAlgebra;
using VectorF = MathNet.Numerics.LinearAlgebra.Vector<float>;

namespace JTSim
{
    public class FirstOrder : ContinousModel
    {
        public float k = 2.0f;
        public float T = 1.0f;

        public FirstOrder (float initState) 
        {
            this.initState = VectorF.Build.Dense(1, initState);
        }

        public override VectorF DifferentialEquasions(VectorF state, float input, float t)
        {
            VectorF diff = -1.0f / T * state + k / T * input;
            return diff;
        }

        public override float OutputEquation(VectorF state, float input)
        {
            return state[0];
        }
    }
}
