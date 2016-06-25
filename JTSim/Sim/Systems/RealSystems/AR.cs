using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorF = MathNet.Numerics.LinearAlgebra.Vector<float>;

namespace JTSim
{
    public class AR : DiscreteModel
    {
        /*
        model AR:
        transmitacja: K(z) = (0.5z + 1)/(z^3 -0.5z^2 - 0.2z - 0.2)
        równanie różnicowe: y(i) = 0.5y(i-1) + 0.2y(i-2) + 0.2y(i-3) + 0.5u(i-2) + u(i-3)
        */

        public AR (float y_1, float y_2, float y_3)
        {
            initStates = VectorF.Build.Dense(new float[] { y_1, y_2, y_3 });
            initInputs = VectorF.Build.Dense(3, 0f);
        }

        public override float DifferenceEquasion(VectorF states, VectorF inputs, float t, float h)
        {
            return 0.5f * states[0] + 0.2f * states[1] + 0.2f * states[2] + 0.5f * inputs[1] + 1f * inputs[2];
        }

        public override float OutputEquation(VectorF states, VectorF inputs)
        {
            return states[0];
        }
    }
}
