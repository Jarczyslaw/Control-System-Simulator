using JTControlSystem;
using JTControlSystem.SignalGenerators;
using JTControlSystemChart;
using MicroLibrary;
using OfflineSimulator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities;

namespace RealtimeSimulator
{
    public partial class MainForm : Form
    {
        private SimulationTimer simulationTimer;
        private IterativeSimulator simulator;

        private ControlChart chart;

        // step size
        private double dt = 0.005d;
        // chart refresh interval;
        private double chartInterval = 0.04d;
        // chart time horizon
        private double chartHorizon = 20d;

        public MainForm()
        {
            InitializeComponent();
            MinimumSize = Size;
            InitComboboxes();
            UpdateStartStop(false);

            int chartCapacity = (int)Math.Round(chartHorizon / chartInterval);
            chart = new ControlChart(mainChart, chartCapacity);

            simulationTimer = new SimulationTimer(dt, chartInterval);
            simulationTimer.MainTick += SimulationTimer_MainTick;
            simulationTimer.SideTick += SimulationTimer_SideTick;

            simulator = new IterativeSimulator(SystemAndController.GetSystem(), SystemAndController.GetController());
            var initialData = simulator.Initialize(dt);

            AddDataSample(initialData);
            InitStartupParameters();
        }

        private void InitStartupParameters()
        {
            SetControlSystemMode();
            SetSignalType();
            SetInputValue();
            SetSetValue();
            SetStepsParameters();
            SetWavesParameters();
            SetManualInput();
        }

        private void SimulationTimer_MainTick(long mainTicks)
        {
            simulator.NextIteration();
        }

        private void SimulationTimer_SideTick(long sideTicks)
        {
            UpdateInUIThread(() =>
            {
                var lastSample = simulator.GetLastSample();
                AddDataSample(lastSample);
            });
        }

        private void AddDataSample(ControlSystemDataSample sample)
        {
            chart.AddPoint(sample);
            chart.SetXAxisHorizon(chartHorizon);

            string longFormat = "0.000000";
            string shortFormat = "0.00";
            tbIteration.Text = simulator.Iteration.ToString();
            tbTime.Text = sample.time.ToString(shortFormat);
            tbInput.Text = sample.input.ToString(longFormat);
            tbSystemOutput.Text = sample.systemOutput.ToString(longFormat);
            tbControllerOutput.Text = sample.controllerOutput.ToString(longFormat);
            tbError.Text = sample.error.ToString(longFormat);
        }

        private void UpdateInUIThread(Action updateCallback)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate
                {
                   updateCallback();
                });
            }
            else
                updateCallback();
        }

        private void InitComboboxes()
        {
            var modes = EnumUtilities.EnumToDict<ControlSystemMode>();
            cbMode.DataSource = new BindingSource(modes, null);
            cbMode.SelectedValue = ControlSystemMode.OpenLoop;
            cbMode.SelectedValueChanged += cbMode_SelectedValueChanged;

            var waves = EnumUtilities.EnumToDict<SignalType>();
            cbSignalType.DataSource = new BindingSource(waves, null);
            cbSignalType.SelectedValue = SignalType.Square;
            cbSignalType.SelectedValueChanged += cbSignalType_SelectedValueChanged;
        }

        public void UpdateStartStop(bool started)
        {
            if (started)
            {
                btnStart.Text = "STOP";
                lbStart.Text = "RUNNING";
                lbStart.BackColor = Color.ForestGreen;
                btnReset.Enabled = false;
            }
            else
            {
                btnStart.Text = "START";
                lbStart.Text = "STOPPED";
                lbStart.BackColor = Color.OrangeRed;
                btnReset.Enabled = true;
            }
        }

        #region From GUI

        private void SetControlSystemMode()
        {
            var mode = (ControlSystemMode)cbMode.SelectedValue;
            simulator.ControlSystem.mode = mode;
        }

        private void SetSignalType()
        {
            var signalType = (SignalType)cbSignalType.SelectedValue;
            simulator.signalType = signalType;
        }

        private void SetInputValue()
        {
            double value = GetTrackBarValue(trbInput);
            tbInputValue.Text = value.ToString("0.00");
            simulator.inputValue = value;
        }

        private void SetSetValue()
        {
            double value = GetTrackBarValue(trbSetvalue);
            tbSetpointValue.Text = value.ToString("0.00");
            simulator.setPointValue = value;
        }

        private void SetStepsParameters()
        {
            StepsParametersConverter converter = new StepsParametersConverter();
            if (!converter.Validate(tbStepTimes.Text, tbStepValues.Text))
            {
                MessageBoxEx.Error("Invalid step parameters");
                return;
            }

            double[] times, values;
            converter.Convert(tbStepTimes.Text, tbStepValues.Text, out times, out values);
            simulator.SignalsGenerator.SetStepsParameters(times, values);

            tbSetStepTimes.Text = tbStepTimes.Text;
            tbSetStepValues.Text = tbStepValues.Text;
        }

        private void SetWavesParameters()
        {
            WavesParametersConverter converter = new WavesParametersConverter();
            if (!converter.Validate(tbFrequency.Text, tbAmplitude.Text, tbOffset.Text))
            {
                MessageBoxEx.Error("Invalid waves parameters");
                return;
            }

            double frequency, amplitude, offset;
            converter.Convert(tbFrequency.Text, tbAmplitude.Text, tbOffset.Text, out frequency, out amplitude, out offset);
            simulator.SignalsGenerator.SetWavesParameters(frequency, amplitude, offset);

            tbSetFrequency.Text = tbFrequency.Text;
            tbSetAmplitude.Text = tbAmplitude.Text;
            tbSetOffset.Text = tbOffset.Text;
        }

        private void SetManualInput()
        {
            if (rbManual.Checked)
                simulator.manualInput = true;
            else
                simulator.manualInput = false;
        }

        private double GetTrackBarValue(TrackBar track)
        {
            double min = -10d;
            double max = 10d;
            return track.Value / 100d * (max - min) + min;
        }

        #endregion

        #region Events

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (simulationTimer.Enabled)
            {
                simulationTimer.Stop();
                UpdateStartStop(false);
            }
            else
            {
                simulationTimer.Start();
                UpdateStartStop(true);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            simulationTimer.Reset();
            var initialData = simulator.Initialize(dt);

            chart.Clear();
            AddDataSample(initialData);
        }

        private void cbMode_SelectedValueChanged(object sender, EventArgs e)
        {
            SetControlSystemMode();
        }

        private void cbSignalType_SelectedValueChanged(object sender, EventArgs e)
        {
            SetSignalType();
        }

        private void trbInput_Scroll(object sender, EventArgs e)
        {
            SetInputValue();
        }

        private void trbSetvalue_Scroll(object sender, EventArgs e)
        {
            SetSetValue();
        }

        private void btnSetSteps_Click(object sender, EventArgs e)
        {
            SetStepsParameters();
        }

        private void btnSetWaves_Click(object sender, EventArgs e)
        {
            SetWavesParameters();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (simulationTimer.Enabled)
            {
                Enabled = false;
                simulationTimer.Quit();
            }
        }

        private void rbManual_CheckedChanged(object sender, EventArgs e)
        {
            var radioButton = sender as RadioButton;
            if (radioButton.Checked)
                SetManualInput();
        }

        private void rbWavesGenerator_CheckedChanged(object sender, EventArgs e)
        {
            var radioButton = sender as RadioButton;
            if (radioButton.Checked)
                SetManualInput();
        }

        #endregion
    }
}
