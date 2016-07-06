using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JTSim;
using System.Diagnostics;

namespace SolversTest
{
    public class Tester
    {
        private TestModel model;
        private List<TestEntry> entries = new List<TestEntry>();
        private double[] timeVector;
        private double[] exactValue;

        private Stopwatch stopwatch = new Stopwatch();

        public Tester(TestModel model, ISolver[] solvers)
        {
            this.model = model;
            foreach(ISolver solver in solvers)
            {
                TestEntry te = new TestEntry(model, solver);
                entries.Add(te);
            }
        }

        public void Test(double time, double h)
        {
            int iterations = Convert.ToInt32(time / h);
            timeVector = new double[iterations];
            exactValue = new double[iterations];
            for (int i = 0;i < iterations;i++)
            {
                timeVector[i] = i * h;
                exactValue[i] = model.ExactSolution(timeVector[i]);
            }

            Stopwatch sw = new Stopwatch();
            foreach (TestEntry entry in entries)
            {
                entry.Test(sw, timeVector, h);
                entry.GetMse(exactValue);
            }

            List<double[]>  data = MergeData();

            FileWriter fw = new FileWriter();
            fw.DataToFile(data, @"D://tests/solvers_test.txt");

            foreach (TestEntry entry in entries)
                entry.ShowInfo();
        }

        private List<double[]> MergeData()
        {
            List<double[]> data = new List<double[]>();
            for (int i = 0; i < timeVector.Length; i++)
            {
                double[] row = new double[entries.Count + 2];
                row[0] = timeVector[i];
                row[1] = exactValue[i];
                for (int j = 0; j < entries.Count; j++)
                    row[2 + j] = entries[j].data[i];
                data.Add(row);
            }
            return data;
        }
    }
}
