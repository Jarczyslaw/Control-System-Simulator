using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTControlSystem.SignalGenerators
{
    public class StepsGenerator : ISignalGenerator
    {
        public double[] StepTimes { get; private set; }
        public double[] StepValues { get; private set; }

        public StepsGenerator() : this(1d, 0d) { }

        public StepsGenerator(double stepValue) : this(stepValue, 0d) { }

        public StepsGenerator(double stepValue, double stepTime)
        {
            StepTimes = new double[] { stepTime };
            StepValues = new double[] { stepValue };
        }

        public StepsGenerator(double[] stepTimes, double[] stepValues)
        {
            SetParams(stepTimes, stepValues);
        }

        public void SetParams(double[] stepTimes, double[] stepValues)
        {
            if (stepValues.Length != stepValues.Length)
                throw new Exception("Invalid steps parameters. Step times has different length than step values");

            this.StepTimes = stepTimes;
            this.StepValues = stepValues;
            Array.Sort(stepTimes, stepValues);
        }

        public SignalGeneratorSample GetSample(double t)
        {
            double sample = 0d;
            if (t >= StepTimes.Last())
                sample = StepValues.Last();

            for (int i = 0; i < StepTimes.Length - 1; i++)
            {
                if (t >= StepTimes[i] && t < StepTimes[i + 1])
                    sample = StepValues[i];
            }
            return new SignalGeneratorSample() { time = t, sampleValue = sample };
        }
    }
}
