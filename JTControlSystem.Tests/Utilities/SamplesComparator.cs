using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTControlSystem.Tests
{
    public class SamplesComparator
    {
        private static double tolerance = 0.00001d;

        public static bool Compare(double[] reference, List<OpenLoopDataSample> data)
        {
            return Compare(reference, data.Select(d => d.output).ToArray());
        }

        public static bool Compare(double[] reference, List<CloseLoopDataSample> data)
        {
            return Compare(reference, data.Select(d => d.systemOutput).ToArray());
        }

        public static bool Compare(double[] reference, List<ControlSystemDataSample> data)
        {
            return Compare(reference, data.Select(d => d.systemOutput).ToArray());
        }

        private static bool Compare(double[] reference, double[] data)
        {
            if (reference.Length != data.Length)
                return false;

            bool passed = true;
            for (int i = 0; i < reference.Length; i++)
            {
                if (Math.Abs(data[i] - reference[i]) > tolerance)
                {
                    passed = false;
                    break;
                }
            }
            return passed;
        }


    }
}
