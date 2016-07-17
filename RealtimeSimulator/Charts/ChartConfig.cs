using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace RealtimeSimulator
{
    public class ChartConfig
    {
        public string title;
        public double min;
        public double max;

        public ChartConfig() : this("Value", 0.0, 1.0) { }

        public ChartConfig(string title, double min, double max)
        {
            this.title = title;
            this.min = min;
            this.max = max;
        }
    }
}
