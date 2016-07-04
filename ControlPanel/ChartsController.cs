using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace ControlPanel
{
    public class ChartsController
    {
        private ChartsConfig config;

        private Series output;
        private Series input;
        private Series control;

        private int capacity = 100;
        private int chartPointer;

        public void Init (ChartsConfig config)
        {
            this.config = config;

            output = new Series
            {
                Name = "System output", Color = Color.ForestGreen, ChartType = SeriesChartType.Line, BorderWidth = 3
            };
            input = new Series
            {
                Name = "Set value", Color = Color.Red, ChartType = SeriesChartType.Line, BorderWidth = 3
            };
            control = new Series
            {
                Name = "Regulator output", Color = Color.CadetBlue, ChartType = SeriesChartType.Line, BorderWidth = 3
            };

            config.output.chart.Series.Add(output);
            config.input.chart.Series.Add(input);
            config.control.chart.Series.Add(control);

            InitChart(config.output);
            InitChart(config.input);
            InitChart(config.control);

            Reset();
        }

        public void InitChart(ChartConfigEntry config)
        {
            config.chart.ChartAreas[0].AxisX.Title = "Time [s]";
            config.chart.ChartAreas[0].AxisY.Title = config.title;
            config.chart.ChartAreas[0].AxisX.LabelStyle.Format = "{0.0}";
            config.chart.ChartAreas[0].AxisY.Minimum = config.min;
            config.chart.ChartAreas[0].AxisY.Maximum = config.max;
        }

        public void SetHorizon(int stepsPerUpdate, double h)
        {
            capacity = Convert.ToInt32(config.horizon * 1d / (stepsPerUpdate * h));
        }

        public void Reset ()
        {
            output.Points.Clear();
            input.Points.Clear();
            control.Points.Clear();
            chartPointer = 0;
        }

        public void AddSample (double[] data)
        {
            double time = data[0];

            DataPoint outputPoint = new DataPoint(time, data[3]);
            DataPoint controlPoint = new DataPoint(time, data[2]);
            DataPoint inputPoint = new DataPoint(time, data[1]);

            chartPointer++;
            if (chartPointer <= capacity)
            {
                output.Points.Add(outputPoint);
                input.Points.Add(inputPoint);
                control.Points.Add(controlPoint);
            }
            else
            {
                PushToSeries(output, outputPoint);
                PushToSeries(input, inputPoint);
                PushToSeries(control, controlPoint);
            }
            SetTimeAxis(config.output.chart, output);
            SetTimeAxis(config.input.chart, input);
            SetTimeAxis(config.control.chart, control);
            UpdateCharts();
        }

        public void AddData(List<double[]> data)
        {

        }

        private void UpdateCharts()
        {
            config.output.chart.Update();
            config.input.chart.Update();
            config.control.chart.Update();
        }

        private void PushToSeries(Series serie, DataPoint point)
        {
            if (serie.Points.Count != 0)
            {
                serie.Points.RemoveAt(0);
            }
            serie.Points.Add(point);
        }

        private void SetTimeAxis(Chart chart, Series serie)
        {
            double startTime = 0d;
            if (serie.Points.Count == 0)
                startTime = 0d;
            else
                startTime = serie.Points[0].XValue;

            double endTime = startTime + config.horizon;
            chart.ChartAreas[0].AxisX.Minimum = startTime;
            chart.ChartAreas[0].AxisX.Maximum = endTime;
            chart.ChartAreas[0].RecalculateAxesScale();
        }
    }
}
