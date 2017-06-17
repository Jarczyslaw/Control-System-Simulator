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
        private Chart chart;

        private ControlChartArea inputArea;
        private ControlChartArea systemOutputArea;
        private ControlChartArea controllerOutputArea;

        public ControlChart(Chart chart) : this(chart, 0) { }

        public ControlChart(Chart chart, int capacity)
        {
            this.chart = chart;

            ClearChart();

            inputArea = new ControlChartArea(chart, "Input", Color.Red, capacity);
            systemOutputArea = new ControlChartArea(chart, "System output", Color.Green, capacity);
            controllerOutputArea = new ControlChartArea(chart, "Controller output", Color.Blue, capacity);
        }

        private void ClearChart()
        {
            chart.ChartAreas.Clear();
            chart.Legends.Clear();
            chart.Series.Clear();
        }

        public void AddPoint(ControlSystemDataSample data)
        {
            double time = data.time;
            inputArea.AddPoint(new DataPoint(time, data.input));
            systemOutputArea.AddPoint(new DataPoint(time, data.systemOutput));
            controllerOutputArea.AddPoint(new DataPoint(time, data.controllerOutput.Value));
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
    }
}
