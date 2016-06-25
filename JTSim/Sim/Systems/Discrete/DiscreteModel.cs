using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorF = MathNet.Numerics.LinearAlgebra.Vector<float>;

namespace JTSim
{
    public abstract class DiscreteModel
    {
        public VectorF initStates;
        public VectorF initInputs;

        public abstract float DifferenceEquasion(VectorF states, VectorF inputs, float t, float h);

        public abstract float OutputEquation(VectorF states, VectorF inputs);
    }
}
