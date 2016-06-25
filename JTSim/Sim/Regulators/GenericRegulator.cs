using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTSim
{
    public abstract class GenericRegulator
    {
        public float output;
        public float h;

        public abstract float Step(float setValue, float processValue);

        public virtual void Init() { }
    }
}
