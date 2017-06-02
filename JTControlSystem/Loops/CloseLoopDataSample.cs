using System;
using System.Collections.Generic;
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
    }
}
