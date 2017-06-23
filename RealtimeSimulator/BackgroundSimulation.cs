using MicroLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtimeSimulator
{
    public class BackgroundSimulation
    {
        public MicroTimer timer;

        public BackgroundSimulation()
        {
            timer = new MicroTimer(1000000L);
            timer.MicroTimerElapsed += Timer_MicroTimerElapsed;
        }

        private void Timer_MicroTimerElapsed(object sender, MicroTimerEventArgs timerEventArgs)
        {
            Debug.WriteLine("Tick");
        }

        public void Start()
        {
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
        }

        public void Toggle()
        {

        }

    }
}
