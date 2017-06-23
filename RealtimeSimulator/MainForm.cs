using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RealtimeSimulator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            MinimumSize = Size;
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

        #region Events

        private void btnStart_Click(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {

        }

        private void cbMode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void trbInput_Scroll(object sender, EventArgs e)
        {

        }

        private void trbSetvalue_Scroll(object sender, EventArgs e)
        {

        }

        private void cbSignalType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSetSteps_Click(object sender, EventArgs e)
        {

        }

        private void btnSetWaves_Click(object sender, EventArgs e)
        {

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
