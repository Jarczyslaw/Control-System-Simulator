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

    public class BackgroundSimulation
    {
        public event ReportProgress OnProgress;
        public event ReportFinish OnFinish;
        public event ReportCancelled OnCancel;
        public event ReportException OnException;

        private BackgroundWorker worker;

        private object syncObject = new object();

        public BackgroundSimulation()
        {
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;

            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            worker.ProgressChanged += Worker_ProgressChanged;
            worker.DoWork += Worker_DoWork;
        }

        public void Start(BackgroundSimulationInput iterativeSimulator)
        {
            if (!IsRunning())
                worker.RunWorkerAsync(iterativeSimulator);
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
            worker.ReportProgress(0);

            BackgroundSimulationInput input = (BackgroundSimulationInput)e.Argument;
            double timeHorizon = input.timeHorizon;
            double timeStep = input.timeStep;
            IterativeSimulator simulator = input.iterativeSimulator;

            int iterations = simulator.PrepareSimulation(timeHorizon, timeStep);
            int iterationsPerProgress = iterations / 100;
            int iterationsCounter = 0;
            int progress = 0;
            for (int i = 1;i < iterations;i++)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }

                simulator.NextIteration();

                iterationsCounter++;
                if (iterationsCounter >= iterationsPerProgress)
                {
                    progress++;
                    worker.ReportProgress(progress);
                    iterationsCounter = 0;
                }
            }
            e.Result = simulator.GetData();
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
