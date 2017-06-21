using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfflineSimulator
{
    public delegate void ProgressReportHandler(int progress);

    public class ProgressCounter
    {
        public ProgressReportHandler ProgressReport;

        private int totalIterations;
        private int currentIteration;

        private int reports;
        private double toNextReport;
        private double iterationsPerReport;

        public void Initialize(int iterations)
        {
            totalIterations = iterations;
            currentIteration = 0;
            iterationsPerReport = totalIterations / 100d;
            reports = 0;
            toNextReport = (reports + 1) * iterationsPerReport;
            ProgressReport(0);
        }

        public void NextIteration()
        {
            currentIteration++;
            if (currentIteration >= toNextReport)
            {
                ProgressReport(GetProgress());
                reports++;
                toNextReport = (reports + 1) * iterationsPerReport;
            }
        }

        public int GetProgress()
        {
            int progress = (int)Math.Round(100d * currentIteration / totalIterations);
            if (progress > 100)
                progress = 100;
            return progress;
        }
    }
}
