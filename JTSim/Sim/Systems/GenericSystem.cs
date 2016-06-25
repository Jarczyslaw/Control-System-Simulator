using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorF = MathNet.Numerics.LinearAlgebra.Vector<float>;

namespace JTSim
{
    public abstract class GenericSystem
    {
        public float output;
        public float h;

        public abstract void Step(float u, float t);

        public abstract void Init();
    }
}
