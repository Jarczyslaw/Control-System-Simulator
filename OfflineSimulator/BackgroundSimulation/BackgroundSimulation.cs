using JTControlSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Utilities;

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

        private ProgressCounter progressCounter;

        private object syncObject = new object();

        public BackgroundSimulation()
        {
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;

            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            worker.ProgressChanged += Worker_ProgressChanged;
            worker.DoWork += Worker_DoWork;

            progressCounter = new ProgressCounter();
            progressCounter.ProgressReport += (p) =>
            {
                worker.ReportProgress(p);
            };
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

            // extract all data from worker input
            BackgroundSimulationInput input = (BackgroundSimulationInput)e.Argument;
            double timeHorizon = input.timeHorizon;
            double timeStep = input.timeStep;
            IterativeSimulator simulator = input.iterativeSimulator;

            int iterations = (int)Math.Floor(timeHorizon / timeStep) + 1;
            var executionTime = ExecTime.Run(() =>
            {
                // first iteration - simulation initialization
                simulator.PrepareSimulation(timeStep);
                progressCounter.Initialize(iterations);
                progressCounter.NextIteration();

                // perform calculations
                for (int i = 1; i < iterations; i++)
                {
                    if (worker.CancellationPending)
                    {
                        e.Cancel = true;
                        break;
                    }

                    simulator.NextIteration();
                    progressCounter.NextIteration();
                }
            });
            
            // return result
            BackgroundSimulationOutput output = new BackgroundSimulationOutput()
            {
                totalIterations = iterations,
                timeStep = timeStep,
                executionTime = executionTime,
                data = simulator.GetData()
            };
            e.Result = output;
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
            {
                OnProgress(100);
                OnFinish(e.Result);
            }
            Debug.WriteLine("Worker completed");
        }
    }
}
