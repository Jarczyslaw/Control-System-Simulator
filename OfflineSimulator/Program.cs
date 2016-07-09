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

            double h = 0.0001d;
            Simulator simulator = new Simulator(h);
            simulator.AddRegulator(new P(20));
            simulator.AddSystem(new ContinousSystem(new SecondOrder(0d, 0d), 0d, new SolverEuler()));
            simulator.Init();

            Controller controller = new Controller(simulator);

            Application.Run(new MainForm(controller));
        }
    }
}
