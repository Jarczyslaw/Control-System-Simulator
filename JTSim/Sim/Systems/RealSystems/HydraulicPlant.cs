using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;
using VectorF = MathNet.Numerics.LinearAlgebra.Vector<float>;

namespace JTSim
{
    public class HydraulicPlant : ContinousModel
    {
        public float k = 1f;
        public float T = 1.0f;

        public float max = 5f;

        public HydraulicPlant(float initState)
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
            if (state[0] < 0f)
                state[0] = 0f;
            else if (state[0] > max)
                state[0] = max;
            return state[0];
        }
    }
}
