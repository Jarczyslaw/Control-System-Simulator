using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTControlSystem
{
    public class ControlSystemDataSample
    {
        public double time;
        public ControlSystemMode? mode;
        public bool? feedbackEnabled;
        public double input;
        public double? error;
        public double? controllerOutput;
        public double systemOutput;

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
            data.mode = ControlSystemMode.OpenLoop;
            data.feedbackEnabled = closeLoopSample.feedbackEnabled;
            data.input = closeLoopSample.setValue;
            data.error = closeLoopSample.error;
            data.controllerOutput = closeLoopSample.controllerOutput;
            data.systemOutput = closeLoopSample.systemOutput;
            return data;
        }
    }
}
