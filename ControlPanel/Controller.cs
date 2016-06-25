﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JTSim;

namespace ControlPanel
{
    public class Controller
    {
        public volatile bool running = false;
        public Action<double[], int> realTimeUpdate;
        public double input = 1d;
        public Simulator simulator { get; private set; }

        private MicroLibrary.MicroTimer timer;
        
        

        public Controller(Simulator simulator)
        {
            this.simulator = simulator;
            InitTimer(1000000d * simulator.h);
            
        }

        private void InitTimer(double delay)
        {
            timer = new MicroLibrary.MicroTimer();
            timer.Interval = Convert.ToInt64(delay);
            timer.MicroTimerElapsed += new MicroLibrary.MicroTimer.MicroTimerElapsedEventHandler(OnTimedEvent);
        }

        private void OnTimedEvent(object sender, MicroLibrary.MicroTimerEventArgs timerEventArgs)
        {
            RealTimeStep();
        }

        private void RealTimeStep()
        {
            if (running)
            {
                double[] data = simulator.Step(input);
                realTimeUpdate?.Invoke(data, simulator.iteration);
            }
        }

        public void StartStop()
        {
            if (running)
            {
                timer.Stop();
            }
            else
            {
                timer.Start();
                RealTimeStep();
            }
            running = !running;
        }

        public bool OpenClose()
        {
            if (simulator.mode == Simulator.Modes.ClosedLoop)
            {
                simulator.mode = Simulator.Modes.OpenLoop;
                return false;
            }
            else
            {
                simulator.mode = Simulator.Modes.ClosedLoop;
                return true;
            }
        }

        public void Reset()
        {
            running = false;
            timer.Stop();
            simulator.Init();
        }
    }
}
