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
        public bool feedbackEnabled;
        public double setValue;
        public double error;
        public double controllerOutput;
        public double systemOutput;

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0:0.000000},{1},{2:0.000000},{3:0.000000},{4:0.000000},{5:0.000000}",
                    time, feedbackEnabled ? 1d : 0d, setValue, error, controllerOutput, systemOutput);
        }
    }
}
