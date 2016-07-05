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
        private Chart outputChart;
        private Chart inputChart;
        private Chart controlChart;

        private Series output;
        private Series input;
        private Series control;

        private int capacity = 100;
        private int chartPointer;

        private double horizon;

        public ChartsController(Chart outputChart, Chart inputChart, Chart controlChart)
        {
            this.outputChart = outputChart;
            this.inputChart = inputChart;
            this.controlChart = controlChart;
        }

        public void Init (ControlPanelConfig controlPanelConfig, double h)
        {
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

            outputChart.Series.Add(output);
            inputChart.Series.Add(input);
            controlChart.Series.Add(control);

            InitChart(outputChart, controlPanelConfig.outputChartConfig);
            InitChart(inputChart, controlPanelConfig.inputChartConfig);
            InitChart(controlChart, controlPanelConfig.controlChartConfig);

            Reset();
        }

        public void InitChart(Chart chart, ChartConfig config)
        {
            chart.ChartAreas[0].AxisX.Title = "Time [s]";
            chart.ChartAreas[0].AxisY.Title = config.title;
            chart.ChartAreas[0].AxisX.LabelStyle.Format = "{0.0}";
            chart.ChartAreas[0].AxisY.Minimum = config.min;
            chart.ChartAreas[0].AxisY.Maximum = config.max;
        }

        public void SetHorizon(ControlPanelConfig controlPanelConfig, double h)
        {
            capacity = Convert.ToInt32(controlPanelConfig.chartHorizon * 1d / (controlPanelConfig.stepsPerUpdate * h));
            horizon = controlPanelConfig.chartHorizon;
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
            SetTimeAxis(outputChart, output);
            SetTimeAxis(inputChart, input);
            SetTimeAxis(controlChart, control);
            UpdateCharts();
        }

        public void AddData(List<double[]> data)
        {

        }

        private void UpdateCharts()
        {
            outputChart.Update();
            inputChart.Update();
            controlChart.Update();
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

            double endTime = startTime + horizon;
            chart.ChartAreas[0].AxisX.Minimum = startTime;
            chart.ChartAreas[0].AxisX.Maximum = endTime;
            chart.ChartAreas[0].RecalculateAxesScale();
        }
    }
}
