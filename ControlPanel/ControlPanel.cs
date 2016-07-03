using System;
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
        private ChartsController charts;
        private Controller controller;

        private int stepsPerUpdate = 10;
        private int steps = 0;

        public ControlPanel(int stepsPerUpdate)
        {
            this.stepsPerUpdate = stepsPerUpdate;
            Init();
        }

        public ControlPanel()
        {
            Init();
        }

        private void Init()
        {
            InitializeComponent();

            inputTypeComboBox.SelectedIndex = 0;
            Icon = Properties.Resources.JT;
            UpdateStartStop(false);
            UpdateOpenClose(false);
            UpdateValuesTextBoxes(new double[] { -1d, 0d, 0d, 0d }, -1);
        }

        public void AddController(Controller controller)
        {
            this.controller = controller;
            controller.realTimeUpdate += UpdateFromController;

            charts = new ChartsController(outputChart, inputChart, controlChart,
                10, stepsPerUpdate, controller.simulator.h);
            charts.Init();
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
            }
            else
            {
                startButton.Text = "START";
                startTextBox.Text = "STOPPED";
                startTextBox.BackColor = Color.OrangeRed;
                resetButton.Enabled = true;
            }
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
        }

        public void UpdateFromController(double[] data, int iteration)
        {
            if (steps % stepsPerUpdate == 0)
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
            charts.AddData(data);
            UpdateValuesTextBoxes(data, iteration);
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

        private void startButton_Click(object sender, EventArgs e)
        {
            controller.StartStop();
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

        private void Reset()
        {
            steps = 0;
            controller.Reset();
            charts.Reset();
            UpdateStartStop(false);
            UpdateValuesTextBoxes(new double[] { -1d, 0d, 0d, 0d }, -1);
        }

        private void inputTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ControlPanel_Load(object sender, EventArgs e)
        {

        }

        private void inputTrackBar_Scroll(object sender, EventArgs e)
        {
            inputTextBox.Text = inputTrackBar.Value.ToString();
        }

        private void setValueTrackBar_Scroll(object sender, EventArgs e)
        {
            inputSetTextBox.Text = setValueTrackBar.Value.ToString();
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
    }
}
