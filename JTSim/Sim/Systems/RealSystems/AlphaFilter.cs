using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTSim
{
    public class AlphaFilter : GenericSystem
    {
        float k = 1f;
        float T = 1f;

        float initState;

        public AlphaFilter (float initState)
        {
            this.initState = initState;
        }

        public override void Init()
        {
            output = initState;
        }

        public override void Step(float u, float t)
        {
            float alpha = (float)Math.Exp(-h / T);
            output = output * alpha + (1f - alpha) * u * k;
        }
    }
}
