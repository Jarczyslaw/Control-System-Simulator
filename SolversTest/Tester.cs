using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JTSim;
using System.Diagnostics;
using MathNet.Numerics.LinearAlgebra;

namespace SolversTest
{
    public class Tester
    {
        private TestModel model;
        private List<TestEntry> entries = new List<TestEntry>();
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
            double[] t = new double[iterations];
            double[] exact = new double[iterations];
            for (int i = 0;i < iterations;i++)
            {
                t[i] = i * h;
                exact[i] = model.ExactSolution(t[i]);
            }

            Stopwatch sw = new Stopwatch();
            foreach (TestEntry entry in entries)
            {
                entry.Test(sw, t, h);
                entry.GetMse(exact);
            }
                
            List<double[]> data = new List<double[]>();
            for(int i = 0;i < iterations;i++)
            {
                double[] row = new double[entries.Count + 2];
                row[0] = t[i];
                row[1] = exact[i];
                for(int j = 0;j < entries.Count;j++)
                    row[2 + j] = entries[j].data[i];
                data.Add(row);
            }

            FileWriter fw = new FileWriter();
            fw.DataToFile(data, @"D://test.txt");

            foreach (TestEntry entry in entries)
                entry.ShowInfo();
        }


    }
}
