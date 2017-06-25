using JTControlSystem;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace JTControlSystemChart
{
    public class ControlChart
    {
        public ControlChartArea inputArea { get; private set; }
        public ControlChartArea systemOutputArea { get; private set; }
        public ControlChartArea controllerOutputArea { get; private set; }

        private Chart chart;

        public ControlChart(Chart chart) : this(chart, 0) { }

        public ControlChart(Chart chart, int capacity)
        {
            this.chart = chart;

            chart.ChartAreas.Clear();
            chart.Legends.Clear();
            chart.Series.Clear();

            inputArea = new ControlChartArea(chart, "Input", Color.Red, capacity);
            systemOutputArea = new ControlChartArea(chart, "System output", Color.Green, capacity);
            controllerOutputArea = new ControlChartArea(chart, "Controller output", Color.Blue, capacity);
        }

        public void Clear()
        {
            inputArea.Clear();
            systemOutputArea.Clear();
            controllerOutputArea.Clear();
        }

        public void AddPoint(ControlSystemDataSample data)
        {
            double time = data.time;
            inputArea.AddPoint(new DataPoint(time, data.input));
            systemOutputArea.AddPoint(new DataPoint(time, data.systemOutput));
            controllerOutputArea.AddPoint(new DataPoint(time, data.controllerOutput));
        } 

        public void AddPoints(List<ControlSystemDataSample> data)
        {
            for (int i = 0; i < data.Count; i++)
                AddPoint(data[i]);
        }

        public void SetPoints(List<ControlSystemDataSample> data)
        {
            inputArea.Clear();
            systemOutputArea.Clear();
            controllerOutputArea.Clear();
            AddPoints(data);
        }

        public void FitXAxisToSeries()
        {
            inputArea.FitXAxisToSeries();
            systemOutputArea.FitXAxisToSeries();
            controllerOutputArea.FitXAxisToSeries();
        }

        public void SetYAxis(double min, double max)
        {
            inputArea.SetYAxis(min, max);
            systemOutputArea.SetYAxis(min, max);
            controllerOutputArea.SetYAxis(min, max);
        }

        public void SetXAxisHorizon(double horizon)
        {
            inputArea.SetXAxisHorizon(horizon);
            systemOutputArea.SetXAxisHorizon(horizon);
            controllerOutputArea.SetXAxisHorizon(horizon);
        }
    }
}
