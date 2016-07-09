using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace OfflineSimulator
{
    public class ChartsController
    {
        private Chart outputChart;
        private Chart inputChart;

        private Series output;
        private Series input;
        private Series control;

        public long updateTime;

        private Stopwatch stopwatch = new Stopwatch();

        public ChartsController(Chart outputChart, Chart inputChart)
        {
            this.outputChart = outputChart;
            this.inputChart = inputChart;

            output = new Series
            {
                Name = "System output",
                Color = Color.ForestGreen,
                ChartType = SeriesChartType.Line,
                BorderWidth = 3
            };
            input = new Series
            {
                Name = "Input",
                Color = Color.Red,
                ChartType = SeriesChartType.Line,
                BorderWidth = 3
            };
            control = new Series
            {
                Name = "Regulator output",
                Color = Color.CadetBlue,
                ChartType = SeriesChartType.Line,
                BorderWidth = 3
            };

            InitChart(outputChart);
            InitChart(inputChart);
        }

        public void InitChart(Chart chart)
        {
            chart.ChartAreas[0].AxisX.Title = "Time [s]";
            chart.ChartAreas[0].AxisX.LabelStyle.Format = "{0.0}";
            chart.ChartAreas[0].AxisX.Minimum = 0;
        }

        public void SetMode(bool feedbackEnabled)
        {
            outputChart.Series.Clear();
            inputChart.Series.Clear();
            if (feedbackEnabled)
            {
                outputChart.Series.Add(output);
                outputChart.Series.Add(input);
                inputChart.Series.Add(control);
            }
            else
            {
                outputChart.Series.Add(output);
                inputChart.Series.Add(input);
            }
        }

        public void ClearData()
        {
            output.Points.Clear();
            input.Points.Clear();
            control.Points.Clear();
        }
       
        public void AddData(List<double[]> data)
        {
            stopwatch.Reset();
            stopwatch.Start();
            for(int i = 0;i < data.Count;i++)
            {
                double time = data[i][0];
                DataPoint outputPoint = new DataPoint(time, data[i][3]);
                DataPoint controlPoint = new DataPoint(time, data[i][2]);
                DataPoint inputPoint = new DataPoint(time, data[i][1]);

                output.Points.Add(outputPoint);
                input.Points.Add(inputPoint);
                control.Points.Add(controlPoint);
            }
            Refresh();
            stopwatch.Stop();
            updateTime = stopwatch.ElapsedMilliseconds;
        }

        public void Refresh()
        {
            outputChart.ChartAreas[0].RecalculateAxesScale();
            inputChart.ChartAreas[0].RecalculateAxesScale();
            outputChart.Update();
            inputChart.Update();
        }
    }
}
