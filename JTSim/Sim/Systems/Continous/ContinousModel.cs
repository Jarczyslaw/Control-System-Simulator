using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorF = MathNet.Numerics.LinearAlgebra.Vector<float>;

namespace JTSim
{
    public abstract class ContinousModel
    {
        public VectorF initState;

        public abstract VectorF DifferentialEquasions(VectorF state, float input, float t);

        public abstract float OutputEquation(VectorF state, float input);
    }
}
