using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace ControlPanel
{
    public class ChartsConfig
    {
        public double horizon;

        public ChartConfigEntry output;
        public ChartConfigEntry input;
        public ChartConfigEntry control;

        public ChartsConfig(double horizon, ChartConfigEntry output, ChartConfigEntry input, ChartConfigEntry control)
        {
            this.horizon = horizon;

            this.output = output;
            this.input = input;
            this.control = control;
        }
    }
}
