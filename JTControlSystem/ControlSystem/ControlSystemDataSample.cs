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
        public bool? feedbackEnabled;
        public double input;
        public double? error;
        public double? controllerOutput;
        public double systemOutput;

        public override string ToString()
        {
            double feedbackEnabledData = 0d;
            if (feedbackEnabled.HasValue)
                feedbackEnabledData = feedbackEnabled.Value ? 1d : 0d;

            double errorData = 0d;
            if (error.HasValue)
                errorData = error.Value;

            double controllerOutputData = 0d;
            if (controllerOutput.HasValue)
                controllerOutputData = controllerOutput.Value;

            return string.Format(CultureInfo.InvariantCulture, "{0:0.000000},{1},{2},{3:0.000000},{4:0.000000},{5:0.000000},{6:0.000000}",
                    time, (int)mode, feedbackEnabledData, input, errorData, controllerOutputData, systemOutput);
        }

        public static ControlSystemDataSample FromOpenSample(OpenLoopDataSample openLoopSample)
        {
            var data = new ControlSystemDataSample();
            data.time = openLoopSample.time;
            data.mode = ControlSystemMode.OpenLoop;
            data.feedbackEnabled = null;
            data.input = openLoopSample.input;
            data.error = null;
            data.controllerOutput = null;
            data.systemOutput = openLoopSample.output;
            return data;
        }

        public static ControlSystemDataSample FromCloseSample(CloseLoopDataSample closeLoopSample)
        {
            var data = new ControlSystemDataSample();
            data.time = closeLoopSample.time;
            data.mode = ControlSystemMode.CloseLoop;
            data.feedbackEnabled = closeLoopSample.feedbackEnabled;
            data.input = closeLoopSample.setValue;
            data.error = closeLoopSample.error;
            data.controllerOutput = closeLoopSample.controllerOutput;
            data.systemOutput = closeLoopSample.systemOutput;
            return data;
        }
    }
}
