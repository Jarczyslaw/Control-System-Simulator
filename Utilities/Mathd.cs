using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class Mathd
    {
        public static double Clamp(double value, double min, double max)
        {
            if (value > max)
                return max;
            if (value < min)
                return min;
            return value;
        }

        public static double Clamp01(double value)
        {
            return Clamp(value, 0d, 1d);
        }
    }
}
