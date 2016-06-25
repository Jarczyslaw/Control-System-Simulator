using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTSim
{
    public class TransparentRegulator : GenericRegulator
    {
        public override float Step(float setValue, float processValue)
        {
            output = setValue;
            return output;
        }
    }
}
