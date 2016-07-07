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
        public enum InputType
        {
            Slider, Steps, Sine, Square, Triangle, Saw
        }

        public InterlockedBool running = new InterlockedBool(false);

        public MicroLibrary.MicroTimer timer;

        public Simulator simulator { get; private set; }
        public Action<double[], int> realTimeUpdate;

        public InputType selectedInput = InputType.Slider;
        public double setValue = 0;
        public double inputValue = 0;
        public WaveGenerator waves { get; private set; }
        public StepsGenerator steps { get; private set; }

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
            if (running.Get())
                RealTimeStep();
        }

        private void RealTimeStep()
        {
            double u = ApplyInput();
            double[] data = simulator.Step(u);
            realTimeUpdate?.Invoke(data, simulator.iteration);
        }

        public void Start()
        {
            running.Set(true);
            RealTimeStep();
            timer.Start();
        }

        public void Stop()
        {
            running.Set(false);
            timer.Stop();
        }

        public bool StartStop()
        {
            if (running.Get())
                Stop();
            else
                Start();
            return running.Get();
        }

        public bool IsRunning()
        {
            return running.Get();
        }

        public bool OpenClosedLoop()
        {
            return simulator.ToggleFeedback();
        }

        public void Reset()
        {
            Stop();
            selectedInput = InputType.Slider;
            simulator.Init();
        }

        public List<double[]> FixedSimulation(double time)
        {
            simulator.Init();
            int iterations = Convert.ToInt32(time / simulator.h);
            for (int i = 0;i < iterations;i++)
            {
                simulator.Step(ApplyInput());
            }
            return simulator.data;
        }

        private double ApplyInput()
        {
            if (selectedInput == InputType.Slider)
            {
                if (simulator.feedbackEnabled)
                    return setValue;
                else
                    return inputValue;
            }
            else if (selectedInput == InputType.Steps)
                return steps.GetSample(simulator.GetCurrentTime());
            else if (selectedInput == InputType.Sine)
                return waves.GetSample(WaveGenerator.Waves.Sine, simulator.GetCurrentTime());
            else if (selectedInput == InputType.Square)
                return waves.GetSample(WaveGenerator.Waves.Square, simulator.GetCurrentTime());
            else if (selectedInput == InputType.Triangle)
                return waves.GetSample(WaveGenerator.Waves.Triangle, simulator.GetCurrentTime());
            else if (selectedInput == InputType.Saw)
                return waves.GetSample(WaveGenerator.Waves.Saw, simulator.GetCurrentTime());
            else
                return 0;
        }
    }
}
