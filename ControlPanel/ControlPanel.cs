﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlPanel
{
    public partial class ControlPanel : Form
    {
        private VisualizationForm visualization;

        private ChartsController charts;
        private Controller controller;

        private ControlPanelConfig config;
        
        private int steps = 0;

        public ControlPanel(Controller controller, ControlPanelConfig config)
        {
            this.controller = controller;
            controller.realTimeUpdate += UpdateFromController;

            this.config = config;

            InitializeComponent();
            InitControls();
            Init(config);
        }

        public void Init(ControlPanelConfig config)
        {
            inputTextBox.Text = config.inputMin.ToString("0.00");
            inputSetTextBox.Text = config.setValueMin.ToString("0.00");

            charts = new ChartsController(outputChart, inputChart, controlChart);
            charts.Init(config, controller.simulator.h);
            charts.SetHorizon(config, controller.simulator.h);
        }

        private void InitControls()
        {
            inputTypeComboBox.SelectedIndex = 0;
            Icon = Properties.Resources.JT;
            UpdateStartStop(false);
            UpdateOpenClose(false);
            UpdateValuesTextBoxes(new double[] { -1d, 0d, 0d, 0d }, -1);
            UpdateWavesData();
            UpdateStepsData();
        }

        public void AddVisualization(VisualizationForm visualization)
        {
            this.visualization = visualization;
        }

        private void UpdateValuesTextBoxes(double[] data, int iteration)
        {
            string f = "0.0000";
            iterationTextBox.Text = iteration.ToString();
            timeTextBox.Text = data[0].ToString("0.00");
            setValueTextBox.Text = data[1].ToString(f);
            controlValueTextBox.Text = data[2].ToString(f);
            outputTextBox.Text = data[3].ToString(f);
        }

        private void UpdateStartStop(bool val)
        {
            if (val)
            {
                startButton.Text = "STOP";
                startTextBox.Text = "RUNNING";
                startTextBox.BackColor = Color.ForestGreen;
                resetButton.Enabled = false;
                visualization?.Start();
            }
            else
            {
                startButton.Text = "START";
                startTextBox.Text = "STOPPED";
                startTextBox.BackColor = Color.OrangeRed;
                resetButton.Enabled = true;
                visualization?.Stop();
            }
        }

        private void UpdateWavesData()
        {
            waveCurrentAmplitudeTextBox.Text = controller.waves.amplitude.ToString();
            waveCurrentFrequencyTextBox.Text = controller.waves.frequency.ToString();
            waveCurrentOffsetTextBox.Text = controller.waves.offset.ToString();
        }

        private void UpdateStepsData()
        {
            stepsCurrentTimesTextBox.Text = ArrayToString(controller.steps.stepTimes);
            stepsCurrentValuesTextBox.Text = ArrayToString(controller.steps.stepValues);
        }

        private string ArrayToString(double[] array)
        {
            string result = "";
            int len = array.Length;
            for (int i = 0; i < len; i++)
            {
                result += array[i].ToString();
                if (i != len - 1)
                    result += ", ";
            }
            return result;
        }

        private void UpdateOpenClose(bool val)
        {
            if (val)
            {
                closeLoopTextBox.Text = "ON";
                closeLoopTextBox.BackColor = Color.ForestGreen;
            }
            else
            {
                closeLoopTextBox.Text = "OFF";
                closeLoopTextBox.BackColor = Color.OrangeRed;
            }
            visualization?.OpenCloseLoop(val);
        }

        public void UpdateFromController(double[] data, int iteration)
        {
            if (steps % config.stepsPerUpdate == 0)
            {
                if (InvokeRequired)
                {
                    BeginInvoke((MethodInvoker)delegate
                    {
                        if (controller.IsRunning())
                            UpdateControls(data, iteration);
                    });
                }
                else
                {
                    UpdateControls(data, iteration);
                }
            }
            steps++; 
        }

        public void UpdateControls(double[] data, int iteration)
        {
            charts.AddSample(data);
            UpdateValuesTextBoxes(data, iteration);
            visualization?.Update(data, iteration);
        }

        public void SetInputValue()
        {
            if (inputTypeComboBox.SelectedIndex == 0)
            {
                
            }
            else
            {
                
            }
        }

        private void Reset()
        {
            steps = 0;
            controller.Reset();
            charts.Reset();
            UpdateStartStop(false);
            UpdateValuesTextBoxes(new double[] { -1d, 0d, 0d, 0d }, -1);
            visualization?.Reset();
        }

        private double GetInputValue(double min, double max, int percentage)
        {
            double range = max - min;
            double step = range / 100;
            return min + step * percentage;
        }

        #region EVENTS
        private void fixedSimulationButton_Click(object sender, EventArgs e)
        {
            if (controller.IsRunning())
            {
                DialogResult result = MessageBox.Show("Do you want to reset simulation and perform fixed simulation?", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Cancel)
                    return;
            }
                

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            controller.StartStop();
            UpdateStartStop(controller.IsRunning());
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controller.Start();
            UpdateStartStop(controller.IsRunning());
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controller.Stop();
            UpdateStartStop(controller.IsRunning());
        }

        private void closeLoopButton_Click(object sender, EventArgs e)
        {
            bool newState = controller.OpenClosedLoop();
            UpdateOpenClose(newState);
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void inputTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void inputTrackBar_Scroll(object sender, EventArgs e)
        {
            double value = GetInputValue(config.inputMin, config.inputMax, inputTrackBar.Value);
            inputTextBox.Text = value.ToString("0.00");
        }

        private void setValueTrackBar_Scroll(object sender, EventArgs e)
        {
            double value = GetInputValue(config.setValueMin, config.setValueMax, setValueTrackBar.Value);
            inputSetTextBox.Text = value.ToString("0.00");
        }

        private void ControlPanel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Q)
            {
                controller.StartStop();
                UpdateStartStop(controller.IsRunning());
            }
            else if (e.KeyCode == Keys.W)
            {
                Reset();
            }
        }

        private void ControlPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!controller.timer.StopAndWait(100))
                controller.timer.Abort();
        }


        private void ControlPanel_Shown(object sender, EventArgs e)
        {
            visualization?.Show();
            visualization?.BringToFront();
        }

        private void waveSetButton_Click(object sender, EventArgs e)
        {
            double freq = 0, amp = 0, off = 0;
            if(controller.waves.ValidParams(
                waveFrequencyTextBox.Text, waveAmplitudeTextBox.Text, waveOffsetTextBox.Text,
                ref freq, ref amp, ref off
                ))
            {
                controller.waves.SetParams(freq, amp, off);
                UpdateWavesData();
            }
            else
                MessageBox.Show("Invalid waves' parameters values. Parameters should be positive (frequency and amplitude) double values.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
        }

        private void stepsSetButton_Click(object sender, EventArgs e)
        {
            double[] times;
            double[] values;
            if (controller.steps.ValidParams(stepsTimes.Text, stepsValues.Text, out times, out values))
            {
                controller.steps.SetParams(times, values);
                UpdateStepsData();
            }
            else
                MessageBox.Show("Invalid steps parameters. They should be positive double values separated by ','. Number of steps should be equal to numbers of values.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion


    }
}
