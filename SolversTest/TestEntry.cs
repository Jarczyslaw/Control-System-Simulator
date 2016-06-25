using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JTSim;
using System.Diagnostics;

namespace SolversTest
{
    public class TestEntry
    {
        private List<float> data;

        private TestSystem system;
        private ISolver solver;

        public long duration;

        public TestEntry(TestSystem system, ISolver solver)
        {
            this.system = system;
            this.solver = solver;
        }

        public void Test(Stopwatch stopwatch, float t, float h)
        {
            stopwatch.Reset();
            stopwatch.Start();
            int iterations = Convert.ToInt32(t / h);
            data.Clear();
            data.Add(system.Init());
            for (int i = 1;i < iterations;i++)
            {
                data.Add(system.Step(solver, t, h));
            }
            stopwatch.Stop();
            duration = stopwatch.ElapsedMilliseconds;
        }
    }
}
