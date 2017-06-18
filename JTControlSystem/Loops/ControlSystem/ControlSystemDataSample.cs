using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTControlSystem
{
    public class ControlSystemDataSample
    {
        public double time;
        public ControlSystemMode mode;
        public double input;
        public double error;
        public double controllerOutput;
        public double systemOutput;

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0:0.000000},{1},{2:0.000000},{3:0.000000},{4:0.000000},{5:0.000000}",
                    time, (int)mode, input, error, controllerOutput, systemOutput);
        }

        public static ControlSystemDataSample FromOpenSample(BareSystemDataSample openLoopSample)
        {
            var data = new ControlSystemDataSample();
            data.time = openLoopSample.time;
            data.mode = ControlSystemMode.OpenLoop;
            data.input = openLoopSample.input;
            data.error = 0d;
            data.controllerOutput = 0d;
            data.systemOutput = openLoopSample.output;
            return data;
        }

        public static ControlSystemDataSample FromCloseSample(CloseLoopDataSample closeLoopSample)
        {
            var data = new ControlSystemDataSample();
            data.time = closeLoopSample.time;
            data.mode = ControlSystemMode.CloseLoop;
            data.input = closeLoopSample.input;
            data.error = closeLoopSample.error;
            data.controllerOutput = closeLoopSample.controllerOutput;
            data.systemOutput = closeLoopSample.systemOutput;
            return data;
        }
    }
}
