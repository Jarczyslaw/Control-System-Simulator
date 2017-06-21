using JTControlSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfflineSimulator
{
    public class BackgroundSimulationOutput
    {
        public int totalIterations;
        public double timeStep;
        public long executionTime;
        public List<ControlSystemDataSample> data;
    }
}
