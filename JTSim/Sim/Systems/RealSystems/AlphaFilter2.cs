using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorF = MathNet.Numerics.LinearAlgebra.Vector<float>;

namespace JTSim
{
    public class AlphaFilter2 : DiscreteModel
    {
        float k = 1f;
        float T = 1f;

        public AlphaFilter2 (float initState)
        {
            this.initStates = VectorF.Build.Dense(1, initState);
            this.initInputs = VectorF.Build.Dense(1, 0f);
        }

        public override float DifferenceEquasion(VectorF states, VectorF inputs, float t, float h)
        {
            float alpha = (float)Math.Exp(-h / T);
            return states[0] * alpha + (1 - alpha) * k * inputs[0]; 
        }

        public override float OutputEquation(VectorF states, VectorF inputs)
        {
            return states[0];
        }
    }
}
