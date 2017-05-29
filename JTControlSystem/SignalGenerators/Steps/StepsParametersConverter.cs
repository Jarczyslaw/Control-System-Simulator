using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTControlSystem.SignalGenerators
{
    public class StepsParametersConverter
    {
        private char[] separator = new[] { ',' };

        public void Convert(string times, string values, out double[] convertedTimes, out double[] convertedValues)
        {
            convertedTimes = ConvertToDoubleArray(times);
            convertedValues = ConvertToDoubleArray(values);
        }

        private double[] ConvertToDoubleArray(string values)
        {
            var valuesArray = values.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            var result = new double[valuesArray.Length];
            for (int i = 0; i < valuesArray.Length; i++)
                result[i] = double.Parse(valuesArray[i], NumberStyles.Any, CultureInfo.InvariantCulture);
            return result;
        }

        public bool Validate(string times, string values)
        {
            if (!CheckEmptiness(times, values))
                return false;

            string[] timesArray = times.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            string[] valuesArray = values.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            if (!CheckLengths(timesArray, valuesArray))
                return false;

            if (!CheckDoubleConcluding(timesArray) || !CheckDoubleConcluding(valuesArray))
                return false;

            double[] convertedTimes, convertedValues;
            Convert(times, values, out convertedTimes, out convertedValues);

            if (!CheckPositive(convertedTimes))
                return false;

            return true;
        }

        private bool CheckEmptiness(string times, string values)
        {
            return !string.IsNullOrEmpty(times) && !string.IsNullOrEmpty(values);
        }

        private bool CheckLengths(string[] times, string[] values)
        {
            if (times.Length == 0 || values.Length == 0)
                return false;

            if (times.Length != values.Length)
                return false;

            return true;
        }

        private bool CheckDoubleConcluding(string[] array)
        {
            for (int i = 0;i < array.Length;i++)
            {
                double value;
                if (!double.TryParse(array[i], NumberStyles.Any, CultureInfo.InvariantCulture, out value))
                    return false;
            }
            return true;
        }

        private bool CheckPositive(double[] array)
        {
            return array.All(number => number >= 0d);
        }
    }
}
