using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace JTControlSystemChart
{
    public class ControlChartArea
    {
        private ChartArea chartArea;
        private Series series;
        private Legend legend;

        private int capacity;

        public ControlChartArea(Chart chart, string title, Color color) : this(chart, title, color, 0) { }

        public ControlChartArea(Chart chart, string title, Color color, int capacity)
        {
            this.capacity = capacity;

            var initializer = new ChartAreaInitializer(chart, title, color);
            initializer.Initialize(ref chartArea, ref series, ref legend);
        }

        public void AddPoint(DataPoint point)
        {
            series.Points.Add(point);
            if (capacity > 0 && series.Points.Count > capacity)
                series.Points.RemoveAt(0);
        } 

        public void Clear()
        {
            series.Points.Clear();
        }

        public void FitXAxisToSeries()
        {
            chartArea.AxisX.Minimum = series.Points.Min(p => p.XValue);
            chartArea.AxisX.Maximum = series.Points.Max(p => p.XValue);
            chartArea.RecalculateAxesScale();
        }
    }
}
