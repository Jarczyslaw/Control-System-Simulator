using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtimeSimulator
{
    public class RealtimeSimulatorConfig
    {
        public int stepsPerUpdate = 10;

        public double inputMin = 0.0;
        public double inputMax = 1.0;

        public double setValueMin = 0.0;
        public double setValueMax = 1.0;

        public double chartHorizon = 10.0;

        public ChartConfig outputChartConfig = new ChartConfig();
        public ChartConfig inputChartConfig = new ChartConfig();
        public ChartConfig controlChartConfig = new ChartConfig();
    }
}
