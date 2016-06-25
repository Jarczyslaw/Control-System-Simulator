using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;
using VectorF = MathNet.Numerics.LinearAlgebra.Vector<float>;

namespace JTSim
{
    public class SecondOrder : ContinousModel
    {
        public float k = 2.0f;
        public float T1 = 1.0f;
        public float T2 = 1.0f;

        public SecondOrder(float initState, float initSpeed)
        {
            this.initState = VectorF.Build.Dense(new float[] { initState, initSpeed });
        }

        public override VectorF DifferentialEquasions(VectorF state, float input, float t)
        {
            float d = T1 * T2;
            float first = state[1];
            float second = -(T1 + T2) / d * state[1] - 1 / d * state[0] + k / d * input;
            VectorF diff = VectorF.Build.Dense(new float[] { first, second });
            return diff;
        }

        public override float OutputEquation(VectorF state, float u)
        {
            return state[0];
        }
    }
}
