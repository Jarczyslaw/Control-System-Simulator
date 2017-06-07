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
        public static void Step(BaseLoop loop, double time, SimulatorCallback callback = null)
        {
            Step(loop, time, 1d, callback);
        }

        public static void Step(BaseLoop loop, double time, double stepValue, SimulatorCallback callback = null)
        {
            ISignalGenerator steps = new StepsGenerator(stepValue, 0d);
            SignalSimulation(loop, time, steps, callback);
        }

        public static void SignalSimulation(BaseLoop loop, double time, ISignalGenerator signalGenerator, SimulatorCallback callback = null)
        {
            loop.Initialize();
            callback?.Invoke(0, 0d);

            int iterations = (int)Math.Floor(time / loop.Dt) + 1;
            for (int i = 1;i < iterations;i++)
            {
                double currentTime = i * loop.Dt;
                var signalSample = signalGenerator.GetSample(currentTime);
                loop.NextIteration(signalSample.value);

                callback?.Invoke(i, currentTime);
            }
        }
    }
}
