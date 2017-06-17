using JTControlSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OfflineSimulator
{
    public delegate void ReportProgress(int progressPercentage);
    public delegate void ReportFinish(object result);
    public delegate void ReportCancelled();
    public delegate void ReportException(Exception exception);

    public class BackgroundSimulator
    {
        public event ReportProgress OnProgress;
        public event ReportFinish OnFinish;
        public event ReportCancelled OnCancel;
        public event ReportException OnException;

        private BackgroundWorker worker;

        private object syncObject = new object();

        public BackgroundSimulator()
        {
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;

            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            worker.ProgressChanged += Worker_ProgressChanged;
            worker.DoWork += Worker_DoWork;
        }

        public void Start(BackgroundSimulatorData simulatorData)
        {
            if (!IsRunning())
            {
                worker.RunWorkerAsync(simulatorData);
            }
        }

        public void Cancel()
        {
            if (IsRunning())
                worker.CancelAsync();
        }

        public bool IsRunning()
        {
            lock(syncObject)
                return worker.IsBusy;
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Debug.WriteLine("Worker started");
            BackgroundSimulatorData simulatorData = (BackgroundSimulatorData)e.Argument;




            worker.ReportProgress(0);
            for (int i = 1;i <= 100;i++)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
                if (i > 50)
                    throw new Exception("Test exception");
                Thread.Sleep(100);
                worker.ReportProgress(i);
            }
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            OnProgress(e.ProgressPercentage);
            Debug.WriteLine(string.Format("Progress report: {0}", e.ProgressPercentage));
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
                OnCancel();
            else if (e.Error != null)
                OnException(e.Error);
            else
                OnFinish(e.Result);
            Debug.WriteLine("Worker completed");
        }
    }
}
