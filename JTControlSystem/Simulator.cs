using JTControlSystem.SignalGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTControlSystem
{
    public class Simulator
    {
        public static void Step(BaseLoop loop, double time)
        {
            Step(loop, time, 1d);
        }

        public static void Step(BaseLoop loop, double time, double stepValue)
        {
            ISignalGenerator steps = new StepsGenerator(stepValue, 0d);
            SignalSimulation(loop, time, steps);
        }

        public static void SignalSimulation(BaseLoop loop, double time, ISignalGenerator signalGenerator)
        {
            loop.Initialize();
            double finishTime = time - loop.Dt;
            for (double t = 0d; t <= finishTime; t += loop.Dt)
            {
                var signalSample = signalGenerator.GetSample(t);
                loop.NextIteration(signalSample.value);
            }
        }
    }
}
