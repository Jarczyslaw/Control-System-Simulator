using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JTSim;
using System.Threading;

namespace ControlPanel
{
    public class Controller
    {
        private long running = 0L;

        public Action<double[], int> realTimeUpdate;
        public double input = 1d;
        public Simulator simulator { get; private set; }
        public WaveGenerator waves { get; private set; }
        public StepsGenerator steps { get; private set; }

        public MicroLibrary.MicroTimer timer;
       

        public Controller(Simulator simulator)
        {
            this.simulator = simulator;
            InitTimer(1000000d * simulator.h);
            timer.MicroTimerElapsed += OnTimedEvent;

            waves = new WaveGenerator(0.5, 1, 1);
            steps = new StepsGenerator(new double[] { 5, 10 }, new double[] { 1, 2 });
        }

        private void InitTimer(double delay)
        {
            timer = new MicroLibrary.MicroTimer();
            timer.Interval = Convert.ToInt64(delay);
            
        }

        private void OnTimedEvent(object sender, MicroLibrary.MicroTimerEventArgs timerEventArgs)
        {
            if (IsRunning())
                RealTimeStep();
        }

        private void RealTimeStep()
        {
            double[] data = simulator.Step(input);
            realTimeUpdate?.Invoke(data, simulator.iteration);
        }

        public void Start()
        {
            Interlocked.Exchange(ref running, 1L);
            RealTimeStep();
            timer.Start();
        }

        public void Stop()
        {
            Interlocked.Exchange(ref running, 0L);
            timer.Stop();
        }

        public bool StartStop()
        {
            if (IsRunning())
                Stop();
            else
                Start();
            return IsRunning();
        }

        public bool IsRunning()
        {
            return Interlocked.Read(ref running) == 1L;
        }

        public bool OpenClosedLoop()
        {
            return simulator.ToggleFeedback();
        }

        public void Reset()
        {
            Stop();
            simulator.Init();
        }
    }
}
