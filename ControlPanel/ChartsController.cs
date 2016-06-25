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

        private float horizon;
        private int capacity;
        private int chartPointer;

        public ChartsController(Chart outputChart, Chart inputChart, Chart controlChart,
            float horizon, int divider, float h)
        {
            this.outputChart = outputChart;
            this.inputChart = inputChart;
            this.controlChart = controlChart;

            capacity = Convert.ToInt32(horizon * 1f / (divider * h));
            this.horizon = horizon;
        }

        public void Init ()
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

            outputChart.ChartAreas[0].AxisX.Title = "Time [s]";
            outputChart.ChartAreas[0].AxisY.Title = "Value";
            outputChart.ChartAreas[0].AxisX.LabelStyle.Format = "{0.0}";
            inputChart.ChartAreas[0].AxisX.Title = "Time [s]";
            inputChart.ChartAreas[0].AxisY.Title = "Value";
            inputChart.ChartAreas[0].AxisX.LabelStyle.Format = "{0.0}";
            controlChart.ChartAreas[0].AxisX.Title = "Time [s]";
            controlChart.ChartAreas[0].AxisY.Title = "Value";
            controlChart.ChartAreas[0].AxisX.LabelStyle.Format = "{0.0}";

            Reset();

            SetTimeAxis();
        }

        public void Reset ()
        {
            output.Points.Clear();
            input.Points.Clear();
            control.Points.Clear();
            chartPointer = 0;
        }

        public void AddData (float[] data)
        {
            float time = data[0];

            DataPoint outputPoint = new DataPoint(time, data[3]);
            DataPoint controlPoint = new DataPoint(time, data[2]);
            DataPoint setValuePoint = new DataPoint(time, data[1]);

            chartPointer++;
            if (chartPointer <= capacity)
            {
                output.Points.Add(outputPoint);
            }
            else
            {
                PushToSeries(output, outputPoint);
            }
            SetTimeAxis();
            UpdateCharts();
            Console.WriteLine(time);
        }

        private void UpdateCharts()
        {
            outputChart.Update();
            inputChart.Update();
        }

        private void PushToSeries(Series serie, DataPoint point)
        {
            if (serie.Points.Count != 0)
            {
                serie.Points.RemoveAt(0);
            }
            serie.Points.Add(point);
        }

        private void SetTimeAxis()
        {
            double startTime = 0d;
            if (output.Points.Count == 0)
                startTime = 0d;
            else
                startTime = output.Points[0].XValue;

            double endTime = startTime + horizon - 1d;
            outputChart.ChartAreas[0].AxisX.Minimum = startTime;
            outputChart.ChartAreas[0].AxisX.Maximum = endTime;
            outputChart.ChartAreas[0].RecalculateAxesScale();
        }
    }
}
