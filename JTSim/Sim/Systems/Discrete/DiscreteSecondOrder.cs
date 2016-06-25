using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorF = MathNet.Numerics.LinearAlgebra.Vector<float>;

namespace JTSim
{
    public class DiscreteSecondOrder : DiscreteModel
    {
        float k = 2f;
        float T1 = 1f;
        float T2 = 1f;

        public DiscreteSecondOrder(float y_1, float y_2)
        {
            initStates = VectorF.Build.Dense(new float[] { y_1, y_2 });
            initInputs = VectorF.Build.Dense(1, 0f);
        }

        public override float DifferenceEquasion(VectorF states, VectorF inputs, float t, float h)
        {
            float A = h * h + h * (T1 + T2) + T1 * T2;
            float B = -2f * T1 * T2 - h * (T1 + T2);
            float C = T1 * T2;
            float D = k * h * h;

            return -B/A * states[0] - C/A * states[1] + D/A * inputs[0];
        }

        public override float OutputEquation(VectorF states, VectorF inputs)
        {
            return states[0];
        }
    }
}
