using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JTControlSystemTests
{
    public class ReferenceDataLoader
    {
        public static double[] Load(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            for (int i = 0;i < lines.Length;i++)
                lines[i] = lines[i].Trim().Replace('.', ',');
            var values = Array.ConvertAll(lines, double.Parse);
            return values;
        }
    }
}
