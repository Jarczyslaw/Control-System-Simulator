using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class ExecTime
    {
        private static Stopwatch stopwatch = new Stopwatch();

        public static long Run(Action codeToExecute)
        {
            stopwatch.Restart();
            codeToExecute();
            stopwatch.Stop();
            long millis = stopwatch.ElapsedMilliseconds;
            Debug.WriteLine(string.Format("Code execution time: {0}ms", millis));
            return millis;
        }
    }
}
