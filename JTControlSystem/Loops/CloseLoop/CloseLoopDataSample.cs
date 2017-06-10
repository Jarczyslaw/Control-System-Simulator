using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTControlSystem
{
    public class CloseLoopDataSample
    {
        public double time;
        public double input;
        public double error;
        public double controllerOutput;
        public double systemOutput;

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0:0.000000},{1:0.000000},{2:0.000000},{3:0.000000},{4:0.000000}",
                    time, input, error, controllerOutput, systemOutput);
        }
    }
}
