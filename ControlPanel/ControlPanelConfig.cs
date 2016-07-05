using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlPanel
{
    public class ControlPanelConfig
    {
        public int stepsPerUpdate = 10;

        public double inputMin = 0;
        public double inputMax = 1;

        public double setValueMin = 0;
        public double setValueMax = 1;

        public double chartHorizon = 10;

        public ChartConfig outputChartConfig = new ChartConfig();
        public ChartConfig inputChartConfig = new ChartConfig();
        public ChartConfig controlChartConfig = new ChartConfig();
    }
}
