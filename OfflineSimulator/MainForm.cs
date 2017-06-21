using JTControlSystem;
using JTControlSystem.SignalGenerators;
using JTControlSystemChart;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities;

namespace OfflineSimulator
{
    public partial class MainForm : Form
    {
        private BackgroundSimulation backgroundSimulation;
        private IterativeSimulator iterativeSimulator;

        private ControlChart chart;
        private int pointsPerSecond = 10;

        private List<ControlSystemDataSample> resultData;

        public MainForm()
        {
            InitializeComponent();

            MinimumSize = Size;
            MainForm_Resize(null, null);
            UpdateSimulationState(false);
            InitComboboxes();

            backgroundSimulation = new BackgroundSimulation();
            backgroundSimulation.OnCancel += Simulator_OnCancel;
            backgroundSimulation.OnException += Simulator_OnException;
            backgroundSimulation.OnFinish += Simulator_OnFinish;
            backgroundSimulation.OnProgress += Simulator_OnProgress;

            iterativeSimulator = new IterativeSimulator();

            chart = new ControlChart(chart1, 0);
        }

        private void InitComboboxes()
        {
            var modes = Utils.EnumToDict<ControlSystemMode>();
            cbMode.DataSource = new BindingSource(modes, null);
            cbMode.SelectedValue = ControlSystemMode.CloseLoop;

            var waves = Utils.EnumToDict<SignalType>();
            cbInputType.DataSource = new BindingSource(waves, null);
            cbInputType.SelectedValue = SignalType.Steps;
        }

        private BackgroundSimulationInput GetSimulationInput()
        {
            var input = new BackgroundSimulationInput();
            input.timeHorizon = double.Parse(tbTimeHorizon.Text);
            input.timeStep = double.Parse(tbTimeStep.Text);

            pointsPerSecond = int.Parse(tbPointsPerSecond.Text);
            iterativeSimulator.initialMode = (ControlSystemMode)cbMode.SelectedValue;

            iterativeSimulator.waveType = (SignalType)cbInputType.SelectedValue;
            StepsParametersConverter stepsConverter = new StepsParametersConverter();
            double[] stepTimes, stepValues;
            stepsConverter.Convert(tbStepTimes.Text, tbStepValues.Text, out stepTimes, out stepValues);
            iterativeSimulator.WavesGenerator.SetStepsParameters(stepTimes, stepValues);

            double frequency, amplitude, offset;
            WavesParametersConverter wavesConverter = new WavesParametersConverter();
            wavesConverter.Convert(tbFrequency.Text, tbAmplitude.Text, tbOffset.Text, out frequency, out amplitude, out offset);
            iterativeSimulator.WavesGenerator.SetWavesParameters(frequency, amplitude, offset);

            input.iterativeSimulator = iterativeSimulator;
            return input;
        }

        private bool ParametersValidation()
        {
            double timeHorizon = 0d;
            if (!double.TryParse(tbTimeHorizon.Text, out timeHorizon) || timeHorizon <= 0d)
            {
                MessageBoxEx.Error("Invalid start time or end time value.");
                return false;
            }

            double stepSize = 0d;
            if (!double.TryParse(tbTimeStep.Text, out stepSize) || stepSize <= 0d)
            {
                MessageBoxEx.Error("Invalid step size value");
                return false;
            }

            int pointsPerSecond = 0;
            if (!int.TryParse(tbPointsPerSecond.Text, out pointsPerSecond) || pointsPerSecond < 1)
            {
                MessageBoxEx.Error("Invalid points per second value");
                return false;
            }

            StepsParametersConverter stepsConverter = new StepsParametersConverter();
            if (!stepsConverter.Validate(tbStepTimes.Text, tbStepValues.Text))
            {
                MessageBoxEx.Error("Invalid step times or step values");
                return false;
            }

            WavesParametersConverter wavesConverter = new WavesParametersConverter();
            if (!wavesConverter.Validate(tbAmplitude.Text, tbAmplitude.Text, tbOffset.Text))
            {
                MessageBoxEx.Error("Invalid waves parameters");
                return false;
            }

            return true;
        }

        private List<ControlSystemDataSample> ExtractChartData(BackgroundSimulationOutput output)
        {
            var data = output.data;
            int skipSamples = (int)((1d / output.timeStep) / pointsPerSecond);
            if (skipSamples != 0)
                return data.Where((s, i) => i % skipSamples == 0).ToList();
            else
                return data;
        }

        private void StartClosingTask()
        {
            Task.Run(() =>
            {
                while (backgroundSimulation.IsRunning()) ;
                Invoke((MethodInvoker)delegate 
                {
                    Close();
                });
            });
        }

        #region Simulator events

        private void Simulator_OnProgress(int progressPercentage)
        {
            UpdateProgress(progressPercentage);
        }

        private void Simulator_OnFinish(object result)
        {
            UpdateSimulationState(false);

            var output = result as BackgroundSimulationOutput;

            var plottingTime = ExecTime.Run(() =>
            {
                resultData = ExtractChartData(output);
                chart.SetPoints(resultData);
                chart.FitXAxisToSeries();
            });

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Simulation finished!");
            sb.AppendLine(string.Format("Generated total {0} points", output.data.Count));
            sb.AppendLine(string.Format("Plotted {0} points", resultData.Count));
            sb.AppendLine(string.Format("Simulation time: {0} ms", output.executionTime));
            sb.AppendLine(string.Format("Plotting time: {0} ms", plottingTime));
            MessageBoxEx.Info(sb.ToString());
        }

        private void Simulator_OnException(Exception exception)
        {
            UpdateProgress(0);
            UpdateSimulationState(false);
            MessageBoxEx.Error("An exception occured in worker: " + exception.Message);
        }

        private void Simulator_OnCancel()
        {
            UpdateProgress(0);
            UpdateSimulationState(false);
            MessageBoxEx.Info("Simulation cancelled");
        }

        private void UpdateSimulationState(bool running)
        {
            if (running)
            {
                tbSimulationState.Text = "RUNNING";
                tbSimulationState.BackColor = Color.GreenYellow;
            }
            else
            {
                tbSimulationState.Text = "STOPPED";
                tbSimulationState.BackColor = Color.OrangeRed;
            }
        }

        private void UpdateProgress(int progress)
        {
            statusProgressBar.Value = progress;
            statusProgressLabel.Text = string.Format("{0}%", progress);
        }

        #endregion

        #region Events

        private void startButton_Click(object sender, EventArgs e)
        {
            if (backgroundSimulation.IsRunning())
            {
                MessageBoxEx.Info("Simulation in progress");
                return;
            }

            if (!ParametersValidation())
                return;

            UpdateSimulationState(true);

            resultData = null;
            var input = GetSimulationInput();
            backgroundSimulation.Start(input);
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            if (!backgroundSimulation.IsRunning())
            {
                MessageBoxEx.Info("Simulation is already stopped");
                return;
            }
                
            UpdateSimulationState(false);
            backgroundSimulation.Cancel();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            statusProgressBar.Width = Width - statusLabel.Width - statusProgressLabel.Width - 40;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (backgroundSimulation.IsRunning())
            {
                backgroundSimulation.Cancel();
                Enabled = false;
                FormClosing -= MainForm_FormClosing;
                e.Cancel = true;

                StartClosingTask();
            }
        }

        private void btnSaveToFile_Click(object sender, EventArgs e)
        {
            if (resultData != null && resultData.Count != 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.FileName = "data";
                sfd.DefaultExt = "txt";
                sfd.ValidateNames = true;
                sfd.Filter = "Text file (.txt)|*.txt";

                DialogResult dr = sfd.ShowDialog();
                if (dr == DialogResult.OK)
                    FileWriter.ToFile(resultData, sfd.FileName);
            }
            else
                MessageBoxEx.Error("Data is empty. Run simulation before saving!");
        }

        #endregion

    }
}
