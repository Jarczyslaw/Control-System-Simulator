using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OfflineSimulator
{
    public partial class MainForm : Form
    {
        private Controller controller;
        private ChartsController charts;

        public MainForm(Controller controller)
        {
            InitializeComponent();
            wavesComboBox.SelectedIndex = 0;
            modeComboBox.SelectedIndex = 0;

            this.controller = controller;
            this.controller.parent = this;

            charts = new ChartsController(outputChart, inputChart);
            charts.SetMode(controller.simulator.feedbackEnabled);
        }

        private void Start()
        {
            if(!controller.running)
            {
                double timeHorizon = 0;
                if (!double.TryParse(timeHorizonTextBox.Text, out timeHorizon))
                {
                    MessageBox.Show("Invalid start time or end time value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                double stepSize = 0, pointsPerSecond = 0;
                if (!double.TryParse(stepSizeTextBox.Text, out stepSize) || !double.TryParse(pointsPerSecondTextBox.Text, out pointsPerSecond))
                {
                    MessageBox.Show("Invalid step size or steps per point value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                double frequency = 0, amplitude = 0, offset = 0;
                if (!controller.waves.ValidParams(frequencyTextBox.Text, amplitudeTextBox.Text, offsetTextBox.Text,
                    ref frequency, ref amplitude, ref offset))
                {
                    MessageBox.Show("Invalid waves generator parameters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                double[] times, values;
                if (!controller.steps.ValidParams(stepsTimesTextBox.Text, stepsValuesTextBox.Text,
                    out times, out values))
                {
                    MessageBox.Show("Invalid steps generator parameters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int inputType = 0;
                if (wavesRadioButton.Checked)
                    inputType = 1;

                int mode = modeComboBox.SelectedIndex;

                charts.ClearData();
                charts.SetMode(mode == 1);
                controller.SetInputParams(wavesComboBox.SelectedIndex, amplitude, frequency, offset, times, values);
                controller.Start(mode, timeHorizon, stepSize, pointsPerSecond, inputType);
            }
            else
                MessageBox.Show("Simulator is currently working. Stop it and run again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Stop()
        {
            controller.Stop();
        }

        private void SaveToFile()
        {
            if (!controller.running)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.FileName = "data";
                sfd.DefaultExt = "txt";
                sfd.ValidateNames = true;
                sfd.Filter = "Text file (.txt)|*.txt";

                DialogResult dr = sfd.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    if (controller.SaveDataToFile(sfd.FileName))
                        MessageBox.Show("File saved!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Data is empty. Run simulation before saving!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Simulator is currently working. Wait for simulation complete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void UpdateProgress(int i)
        {
            progressProgressBar.Value = i;
            percentageStatusLabel.Text = i.ToString() + "%";
        }

        public void WorkFinished(int status, List<double[]> data)
        {
            if (status == -2)
                MessageBox.Show("Simulation cancelled!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (status == -1)
                MessageBox.Show("Something went totally wrong!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                Console.WriteLine("Finish with data: " + data.Count);
                charts.AddData(data);
                MessageBox.Show("Simulation finished!" + Environment.NewLine +
                    "Generated total " + controller.simulator.data.Count + " points" + Environment.NewLine +
                    "Plotted " + data.Count + " data points." + Environment.NewLine +
                    "Simulation time: " + controller.simulationTime + " ms" + Environment.NewLine +
                    "Plotting time: " + charts.updateTime + " ms", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #region EVENTS
        private void startButton_Click(object sender, EventArgs e)
        {
            Start();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            Stop();
        }

        private void saveToFileButton_Click(object sender, EventArgs e)
        {
            SaveToFile();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (controller.running)
            {
                controller.pendingClose = true;
                controller.Stop();
                e.Cancel = true;
            }
        }
        #endregion
    }
}
