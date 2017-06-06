using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTControlSystem
{
    public static class FileWriter
    {
        public static void ToFile(List<BareSystemDataSample> data, string filePath, bool append = false)
        {
            WriteToFile(data.Cast<object>().ToList(), filePath, append);
        }

        public static void ToFile(List<OpenLoopDataSample> data, string filePath, bool append = false)
        {
            WriteToFile(data.Cast<object>().ToList(), filePath, append);
        }

        public static void ToFile(List<CloseLoopDataSample> data, string filePath, bool append = false)
        {
            WriteToFile(data.Cast<object>().ToList(), filePath, append);
        }

        public static void ToFile(List<ControlSystemDataSample> data, string filePath, bool append = false)
        {
            WriteToFile(data.Cast<object>().ToList(), filePath, append);
        }

        private static void WriteToFile(List<object> data, string filePath, bool append = false)
        {
            var lines = SamplesToLines(data);
            WriteLinesToFile(lines, filePath, append);
        }

        private static string[] SamplesToLines(List<object> samples)
        {
            string[] data = new string[samples.Count];
            for(int i = 0;i < samples.Count;i++)
            {
                var sample = samples[i];
                data[i] = sample.ToString();
            }
            return data;
        }

        private static void WriteLinesToFile(string[] lines, string filePath, bool append = false)
        {
            if (append)
                File.AppendAllLines(filePath, lines);
            else
                File.WriteAllLines(filePath, lines);
        }
    }
}
