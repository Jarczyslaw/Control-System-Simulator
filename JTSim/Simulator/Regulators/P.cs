using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTSim
{
    public class P : GenericRegulator
    {
        public double Kp = 3d;

        public P() { }

        public P(double Kp)
        {
            this.Kp = Kp;
        }

        public override double Step(double setValue, double processValue, double h)
        {
            return Kp * (setValue - processValue);
        }
    }
}
