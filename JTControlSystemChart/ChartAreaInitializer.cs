using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace JTControlSystemChart
{
    public class ChartAreaInitializer
    {
        private Chart chart;
        private string title;
        private Color color;

        public ChartAreaInitializer(Chart chart, string title, Color color)
        {
            this.chart = chart;
            this.title = title;
            this.color = color;
        }

        public void Initialize(ref ChartArea chartArea, ref Series serie, ref Legend legend)
        {
            chartArea = InitChartArea();
            serie = InitSerie(chartArea);
            legend = InitLegend(chartArea, serie);
        }

        private ChartArea InitChartArea()
        {
            var area = new ChartArea(title + "ChartArea");
            chart.ChartAreas.Add(area);
            area.AxisX.LabelStyle.Format = "{0.00}";
            return area;
        }

        private Series InitSerie(ChartArea area)
        {
            var serie = new Series()
            {
                Name = title,
                Color = color,
                ChartType = SeriesChartType.Line,
                BorderWidth = 3
            };
            chart.Series.Add(serie);
            serie.ChartArea = area.Name;
            return serie;
        }

        private Legend InitLegend(ChartArea area, Series serie)
        {
            var legend = new Legend(title + "Legend");
            chart.Legends.Add(legend);
            legend.DockedToChartArea = area.Name;
            legend.Docking = Docking.Top;
            legend.IsDockedInsideChartArea = false;
            legend.BackColor = Color.Transparent;
            serie.Legend = legend.Name;
            return legend;
        }
    }
}
