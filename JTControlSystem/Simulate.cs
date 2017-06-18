using JTControlSystem.SignalGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTControlSystem
{
    public delegate void SimulateCallback(int iteration, double time);

    public class Simulate
    {
        public static void Step(ILoop loop, double time, double dt, SimulateCallback callback = null)
        {
            Step(loop, time, dt, 1d, callback);
        }

        public static void Step(ILoop loop, double time, double dt, double stepValue, SimulateCallback callback = null)
        {
            ISignalGenerator steps = new StepsGenerator(stepValue, 0d);
            Signal(loop, time, dt, steps, callback);
        }

        public static void Signal(ILoop loop, double time, double dt, ISignalGenerator signalGenerator, SimulateCallback callback = null)
        {
            loop.Initialize(dt);
            callback?.Invoke(0, 0d);

            int iterations = (int)Math.Floor(time / dt) + 1;
            for (int i = 1;i < iterations;i++)
            {
                double currentTime = i * dt;
                var signalSample = signalGenerator.GetSample(currentTime);
                loop.NextIteration(signalSample.value, currentTime, dt);

                callback?.Invoke(i, currentTime);
            }
        }
    }
}
