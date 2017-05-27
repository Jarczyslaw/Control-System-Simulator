using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MicroLibraryDemo
{
    public partial class FormMain : Form
    {
        // Declare MicroTimer
        private readonly MicroLibrary.MicroTimer _microTimer;

        public FormMain()
        {
            InitializeComponent();

            // Instantiate new MicroTimer and add event handler
            _microTimer = new MicroLibrary.MicroTimer();
            _microTimer.MicroTimerElapsed +=
                new MicroLibrary.MicroTimer.MicroTimerElapsedEventHandler(OnTimedEvent);
        }

        private void OnTimedEvent(object sender,
                                  MicroLibrary.MicroTimerEventArgs timerEventArgs)
        {
            // Do something small that takes significantly less time than Interval.
            // BeginInvoke executes on the UI thread but this calling thread does not
            //  wait for completion before continuing (i.e. it executes asynchronously)
            if (InvokeRequired)
            {
                BeginInvoke((MethodInvoker)delegate
                {
                    TextBoxElapsedTime.Text = timerEventArgs.ElapsedMicroseconds.ToString("#,#");
                });
            }
        }

        private void ButtonStartClick(object sender, EventArgs e)
        {
            long interval;

            // Read interval from form
            if (!long.TryParse(TextBoxInterval.Text, out interval))
            {
                return;
            }

            // Set timer interval
            _microTimer.Interval = interval;

            // Ignore event if late by half the interval
            _microTimer.IgnoreEventIfLateBy = interval/2;

            // Start timer
            _microTimer.Start();
        }

        private void ButtonStopClick(object sender, EventArgs e)
        {
            // Stop the timer
            _microTimer.Stop();
        }

        private void FormMainFormClosing(object sender, FormClosingEventArgs e)
        {
            // Stop the timer, wait for up to 1 sec for current event to finish,
            //  if it does not finish within this time abort the timer thread
            if (!_microTimer.StopAndWait(1000))
            {
                _microTimer.Abort();
            }
        }
    }
}
