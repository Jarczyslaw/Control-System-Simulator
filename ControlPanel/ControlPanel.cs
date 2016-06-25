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
            UpdateValuesTextBoxes(new float[] { -1f, 0f, 0f, 0f }, -1);
        }

        public void AddController(Controller controller)
        {
            this.controller = controller;
            controller.realTimeUpdate += UpdateFromController;

            charts = new ChartsController(outputChart, inputChart, controlChart,
                10, stepsPerUpdate, controller.simulator.h);
            charts.Init();
        }

        private void UpdateValuesTextBoxes(float[] data, int iteration)
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
            }
            else
            {
                startButton.Text = "START";
                startTextBox.Text = "STOPPED";
                startTextBox.BackColor = Color.OrangeRed;
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

        public void UpdateFromController(float[] data, int iteration)
        {
            if (steps % stepsPerUpdate == 0)
            {
                if (InvokeRequired)
                {
                    BeginInvoke((MethodInvoker)delegate
                    {
                        charts.AddData(data);
                        UpdateValuesTextBoxes(data, iteration);
                    });
                }
            }
            steps++;
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
            UpdateStartStop(controller.running);
        }

        private void closeLoopButton_Click(object sender, EventArgs e)
        {
            bool newState = controller.OpenClose();
            UpdateOpenClose(newState);
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            steps = 0;
            controller.Reset();
            charts.Reset();
            UpdateStartStop(false);
            UpdateValuesTextBoxes(new float[] { -1f, 0f, 0f, 0f }, -1);
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
    }
}
