using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTControlSystem.SignalGenerators
{
    public class SignalSample
    {
        public double time;
        public double value;

        public override bool Equals(object obj)
        {
            var otherSample = (SignalSample)obj;
            return time == otherSample.time && value == otherSample.value;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
