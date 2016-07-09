using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JTSim;
using System.Threading;
using System.Diagnostics;

namespace OfflineSimulator
{
    public class Controller : BackgroundWorker
    {
        private class WorkerInput
        {
            public double timeHorizon;
            public double stepSize;
            public double pointsPerSecond;

            public Simulator simulator;
            public ISignalGenerator generator;

            public WorkerInput(double timeHorizon, double stepSize, double pointsPerSecond)
            {
                this.timeHorizon = timeHorizon;
                this.stepSize = stepSize;
                this.pointsPerSecond = pointsPerSecond;
            }

            public void Add(Simulator simulator, ISignalGenerator generator)
            {
                this.simulator = simulator;
                this.generator = generator;
                this.simulator.h = stepSize;
            }

            public int GetIterationCount()
            {
                return Convert.ToInt32(timeHorizon / stepSize);
            }

            public int GetPointsCount()
            {
                return Convert.ToInt32(timeHorizon * pointsPerSecond);
            }
        }

        public MainForm parent;

        public bool running = false;

        public Simulator simulator { get; private set; }
        public StepsGenerator steps;
        public WavesGenerator waves;

        public bool pendingClose = false;

        public long simulationTime;

        private Stopwatch stopwatch = new Stopwatch();

        public List<double[]> lastData;

        public Controller(Simulator simulator)
        {
            this.simulator = simulator;

            steps = new StepsGenerator();
            waves = new WavesGenerator();

            WorkerReportsProgress = true;
            WorkerSupportsCancellation = true;
            RunWorkerCompleted += new RunWorkerCompletedEventHandler(WorkCompletedHandler);
            ProgressChanged += new ProgressChangedEventHandler(ProgressChangedHandler);
            DoWork += new DoWorkEventHandler(DoWorkHandler);
        }

        public void Start(int mode, double timeHorizon, double stepSize, double stepsPerPoint, int inputType)
        {
            WorkerInput input = new WorkerInput(timeHorizon, stepSize, stepsPerPoint);
            if (inputType == 0)
                input.Add(simulator, steps);
            else
                input.Add(simulator, waves);

            simulator.SetFeedback(mode == 1);

            RunWorkerAsync(input);
            stopwatch.Reset();
            stopwatch.Start();
            running = true;
        }

        public void Stop()
        {
            CancelAsync();    
        }

        public void SetInputParams(int type, double amplitude, double frequency, double offset,
            double[] stepTimes, double[] stepValues)
        {
            waves.SetParams(type, frequency, amplitude, offset);
            steps.SetParams(stepTimes, stepValues);
        }

        private void DoWorkHandler(object sender, DoWorkEventArgs e)
        {
            WorkerInput input = e.Argument as WorkerInput;
            Simulator sim = input.simulator;
            ISignalGenerator gen = input.generator;

            int iters = input.GetIterationCount();
            int stepsPerUpdate = iters / 100;
            int stepsPerPoint = Convert.ToInt32((1 / input.stepSize) / input.pointsPerSecond);
            List<double[]> data = new List<double[]>();

            int progress = 0;
            int stepsToUpdate = 0; int stepsToPoint = stepsPerPoint;
            ReportProgress(0);
            sim.Init();
            for (int i = 0;i < iters;i++)
            {
                double[] sample = sim.Step(gen.GetSample(sim.GetCurrentTime()));

                stepsToPoint++;
                if (stepsToPoint >= stepsPerPoint)
                {
                    data.Add(sample);
                    stepsToPoint = 0;
                }

                stepsToUpdate++;
                if (stepsToUpdate >= stepsPerUpdate)
                {
                    progress++;
                    ReportProgress(progress);
                    stepsToUpdate = 0;
                }
              
                if (CancellationPending)
                {
                    e.Cancel = true;
                    ReportProgress(0);
                    return;
                }
            }
            e.Result = data;
            ReportProgress(100);
        }

        private void ProgressChangedHandler(object sender, ProgressChangedEventArgs e)
        {
            Console.WriteLine("Progress: " + e.ProgressPercentage);
            parent.UpdateProgress(e.ProgressPercentage);  
        }

        private void WorkCompletedHandler(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
                parent.WorkFinished(-2, null);
            else if (e.Error != null)
                parent.WorkFinished(-1, null);
            else
            {
                if (e.Result != null)
                {
                    stopwatch.Stop();
                    simulationTime = stopwatch.ElapsedMilliseconds;

                    List<double[]> data = e.Result as List<double[]>;
                    lastData = data;
                    parent.WorkFinished(0, data);
                }
                else
                    Console.WriteLine("Result is null");
            }

            running = false;
            if (pendingClose)
                parent.Close();
        }
    }
}
