using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using JTSim;

namespace OfflineSimulator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            CultureInfo customCulture = (CultureInfo)Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            Thread.CurrentThread.CurrentCulture = customCulture;

            Simulator simulator = new Simulator();
            simulator.AddRegulator(new PID(3.0255, 1.0917, 0.23101));
            simulator.AddSystem(new ContinousSystem(new SecondOrder(0d, 0d, 2, 1, 0.5), 0d, new SolverRK4()));
            simulator.Init();

            Controller controller = new Controller(simulator);

            Application.Run(new MainForm(controller));
        }
    }
}
