using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTControlSystem.SignalGenerators
{
    public class WavesParametersConverter
    {
        public void Convert(string frequency, string amplitude, string offset,
            out double frequencyValue, out double amplitudeValue, out double offsetValue)
        {
            frequencyValue = ToDouble(frequency);
            amplitudeValue = ToDouble(amplitude);
            offsetValue = ToDouble(offset);
        }

        public bool Validate(string frequency, string amplitude, string offset)
        {
            if (!CheckEmptiness(frequency, amplitude, offset))
                return false;

            if (!IsValidDouble(frequency) || !IsValidDouble(amplitude) || !IsValidDouble(offset))
                return false;

            double frequencyValue = ToDouble(frequency);
            double amplitudeValue = ToDouble(amplitude);
            double offsetValue = ToDouble(offset);

            if (frequencyValue <= 0d || amplitudeValue <= 0d)
                return false;

            return true;
        }

        private bool CheckEmptiness(string frequency, string amplitude, string offset)
        {
            return !string.IsNullOrEmpty(frequency) && !string.IsNullOrEmpty(amplitude) && !string.IsNullOrEmpty(offset);
        }

        private double ToDouble(string value)
        {
            return double.Parse(value, NumberStyles.Any, CultureInfo.InvariantCulture);
        }

        private bool IsValidDouble(string value)
        {
            double convertedValue;
            return double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out convertedValue);
        }
    }
}
