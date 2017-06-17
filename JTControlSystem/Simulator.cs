using JTControlSystem.SignalGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTControlSystem
{
    public delegate void SimulatorCallback(int iteration, double time);

    public class Simulator
    {
        public static void Step(ILoop loop, double time, double dt, SimulatorCallback callback = null)
        {
            Step(loop, time, dt, 1d, callback);
        }

        public static void Step(ILoop loop, double time, double dt, double stepValue, SimulatorCallback callback = null)
        {
            ISignalGenerator steps = new StepsGenerator(stepValue, 0d);
            SignalSimulation(loop, time, dt, steps, callback);
        }

        public static void SignalSimulation(ILoop loop, double time, double dt, ISignalGenerator signalGenerator, SimulatorCallback callback = null)
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
