using JTControlSystem;
using JTControlSystem.SignalGenerators;
using JTControlSystemChart;
using OfflineSimulator;
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

namespace RealtimeSimulator
{
    public partial class MainForm : Form
    {
        private BackgroundSimulation backgroundSimulation;

        private ControlChart chart;

        private WavesGenerator wavesGenerator;

        public MainForm()
        {
            InitializeComponent();
            MinimumSize = Size;
            InitComboboxes();
            UpdateStartStop(false);


            backgroundSimulation = new BackgroundSimulation();
            wavesGenerator = new WavesGenerator();

            chart = new ControlChart(chart1);
        }

        private void InitComboboxes()
        {
            var modes = EnumUtilities.EnumToDict<ControlSystemMode>();
            cbMode.DataSource = new BindingSource(modes, null);
            cbMode.SelectedValue = ControlSystemMode.CloseLoop;

            var waves = EnumUtilities.EnumToDict<SignalType>();
            cbSignalType.DataSource = new BindingSource(waves, null);
            cbSignalType.SelectedValue = SignalType.Steps;
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

        public void UpdateSimulationData(ControlSystemDataSample data)
        {
            tbTime.Text = data.time.ToString();
            tbIteration.Text = "0";
            tbInput.Text = data.input.ToString();
            tbSystemOutput.Text = data.systemOutput.ToString();
            tbControllerOutput.Text = data.controllerOutput.ToString();
        }

        #region Events

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (backgroundSimulation.timer.Enabled)
            {
                backgroundSimulation.Stop();
                UpdateStartStop(false);
            }
            else
            {
                backgroundSimulation.Start();
                UpdateStartStop(true);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {

        }

        private void cbMode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void trbInput_Scroll(object sender, EventArgs e)
        {
            tbInputValue.Text = trbInput.Value.ToString();
        }

        private void trbSetvalue_Scroll(object sender, EventArgs e)
        {
            tbSetpointValue.Text = trbSetvalue.Value.ToString();
        }

        private void cbSignalType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSetSteps_Click(object sender, EventArgs e)
        {
            StepsParametersConverter converter = new StepsParametersConverter();
            if (!converter.Validate(tbStepTimes.Text, tbStepValues.Text))
            {
                MessageBoxEx.Error("Invalid step parameters");
                return;
            }

            double[] times, values;
            converter.Convert(tbStepTimes.Text, tbStepValues.Text, out times, out values);
            wavesGenerator.SetStepsParameters(times, values);
        }

        private void btnSetWaves_Click(object sender, EventArgs e)
        {
            WavesParametersConverter converter = new WavesParametersConverter();
            if (!converter.Validate(tbFrequency.Text, tbAmplitude.Text, tbOffset.Text))
            {
                MessageBoxEx.Error("Invalid waves parameters");
                return;
            }

            double frequency, amplitude, offset;
            converter.Convert(tbFrequency.Text, tbAmplitude.Text, tbOffset.Text, out frequency, out amplitude, out offset);
            wavesGenerator.SetWavesParameters(frequency, amplitude, offset);
        }

        private void miSettings_Click(object sender, EventArgs e)
        {

        }

        private void miVisualization_Click(object sender, EventArgs e)
        {

        }

        #endregion


    }
}
