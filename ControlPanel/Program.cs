using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using JTSim;

namespace ControlPanel
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

            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;

            double h = 0.0001d;
            Simulator simulator = new Simulator(h);
            simulator.AddRegulator(new P());
            simulator.AddSystem(new ContinousSystem(new SecondOrder(0d, 0d), 0d, new SolverEuler()));
            simulator.Init();

            Controller controller = new Controller(simulator);
            ControlPanel controlPanel = new ControlPanel(1000);
            controlPanel.AddController(controller);

            Application.Run(controlPanel);
        }
    }
}
