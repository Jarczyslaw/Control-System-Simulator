using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTSim
{
    public class P : GenericRegulator
    {
        public float Kp = 3f;

        public P() { }

        public P(float Kp)
        {
            this.Kp = Kp;
        }

        public override float Step(float setValue, float processValue, float h)
        {
            return Kp * (setValue - processValue);
        }
    }
}
