using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorF = MathNet.Numerics.LinearAlgebra.Vector<float>;

namespace JTSim
{
    public class DiscreteFirstOrder : DiscreteModel
    {
        public float k = 2.0f;
        public float T = 1.0f;

        public DiscreteFirstOrder(float initState)
        {
            this.initStates = VectorF.Build.Dense(1, initState);
            this.initInputs = VectorF.Build.Dense(1, 0f);
        }

        public override float DifferenceEquasion(VectorF states, VectorF inputs, float t, float h)
        {
            return (1f - h / T) * states[0] + k * h / T * inputs[0];
        }

        public override float OutputEquation(VectorF states, VectorF inputs)
        {
            return states[0];
        }
    }
}
