using MicroLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtimeSimulator
{
    public delegate void MainTickHandler(long mainTicks);
    public delegate void SideTickHandler(long sideTicks);

    public class SimulationTimer
    {
        public event MainTickHandler MainTick;
        public event SideTickHandler SideTick;

        private MicroTimer timer;

        private long mainTicks = 0;
        private long sideTicks = 0;
        private long sideTickDivider;

        private InterlockedBool cancellationPending = new InterlockedBool(false);

        public SimulationTimer(double mainTickInterval, double sideTickInterval)
        {
            if (mainTickInterval >= sideTickInterval)
                throw new Exception("Main tick interval must be lower than side tick");

            sideTickDivider = (int)Math.Round(sideTickInterval / mainTickInterval);

            timer = new MicroTimer();
            timer.Interval = Convert.ToInt64(1000000 * mainTickInterval);
            timer.MicroTimerElapsed += Timer_MicroTimerElapsed;
        }

        private void Timer_MicroTimerElapsed(object sender, MicroTimerEventArgs timerEventArgs)
        {
            if (cancellationPending.Get())
                return;

            mainTicks++;
            MainTick(mainTicks);
            if ((mainTicks - 1) % sideTickDivider == 0)
            {
                sideTicks++;
                SideTick(sideTicks);
            }   
        }

        public void Reset()
        {
            timer.Stop();
            mainTicks = 0;
            sideTicks = 0;
        }

        public void Start()
        {
            cancellationPending.Set(false);
            timer.Start();
            Debug.WriteLine("Timer started");
        }

        public void Stop()
        {
            cancellationPending.Set(true);
            timer.Stop();
            Debug.WriteLine("Timer stopped");
        }

        public bool Toggle()
        {
            if (timer.Enabled)
                Stop();
            else
                Start();
            return timer.Enabled;
        }

        public bool Enabled
        {
            get { return timer.Enabled; }
        }

        public void Quit()
        {
            if (!timer.StopAndWait(500))
                timer.Abort();
        }
    }
}
