using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTSim
{
    public class FileWriter
    {
        public FileWriter ()
        {
        }

        private string RowToString(double[] row)
        {
            string res = "";
            for (int i = 0;i < row.Length;i++)
            {
                res += string.Format(CultureInfo.InvariantCulture, "{0:0.000000}", row[i]);
                if (i != row.Length - 1)
                    res += ", ";
            }
            return res;
        }

        public void DataToFile(List<double[]> data, string filePath, bool append = false)
        {

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < data.Count; i++)
            {
                sb.Append(RowToString(data[i]));
                sb.Append(Environment.NewLine);
            }

            if (append)
                File.AppendAllText(filePath, sb.ToString());
            else
                File.WriteAllText(filePath, sb.ToString());   
        }

        public void SimulatorDataToFile(Simulator simulator, string filePath)
        {
            DataToFile(simulator.data, filePath);
        }
    }
}
