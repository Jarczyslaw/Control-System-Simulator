using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JTSim;
using System.Threading;

namespace RealtimeSimulator
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
        public double setValue = 0.0;
        public double inputValue = 0.0;
        public WavesGenerator waves { get; private set; }
        public StepsGenerator steps { get; private set; }

        private FileWriter fileWriter;

        public Controller(Simulator simulator)
        {
            this.simulator = simulator;
            InitTimer(1000000d * simulator.h);
            timer.MicroTimerElapsed += OnTimedEvent;

            waves = new WavesGenerator(0.5, 1.0, 1.0);
            steps = new StepsGenerator(new double[] { 5.0, 10.0 }, new double[] { 1.0, 2.0 });

            fileWriter = new FileWriter();
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
            simulator.Init();
        }

        public bool SaveDataToFile(string filePath)
        {
            if (simulator.data.Count == 0)
                return false;
            else
            {
                fileWriter.DataToFile(simulator.data, filePath);
                return true;
            }
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
                return waves.GetSample(WavesGenerator.Waves.Sine, simulator.GetCurrentTime());
            else if (selectedInput == InputType.Square)
                return waves.GetSample(WavesGenerator.Waves.Square, simulator.GetCurrentTime());
            else if (selectedInput == InputType.Triangle)
                return waves.GetSample(WavesGenerator.Waves.Triangle, simulator.GetCurrentTime());
            else if (selectedInput == InputType.Saw)
                return waves.GetSample(WavesGenerator.Waves.Saw, simulator.GetCurrentTime());
            else
                return 0;
        }
    }
}
