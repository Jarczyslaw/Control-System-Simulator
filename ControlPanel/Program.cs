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

            float h = 0.01f;
            Simulator simulator = new Simulator(h);
            simulator.AddRegulator(new P());
            simulator.AddSystem(new ContinousSystem(new SecondOrder(0f, 0f), 0f, new SolverEuler()));
            //s.AddSystem(new DiscreteSystem(new DiscreteSecondOrder(0.0f, 0f), 1f));
            //s.AddSystem(new AlphaFilter(0.5f));
            //s.AddSystem(new DiscreteSystem(new AlphaFilter2(-0.5f), 1f));
            //s.AddSystem(new DiscreteSystem(new AR(-1f, -1f, -1f)));
            //simulator.AddSystem(new ContinousSystem(new HydraulicPlant(0.5f), 1f, new SolverEuler()));
            simulator.Init();

            Controller controller = new Controller(simulator);
            ControlPanel controlPanel = new ControlPanel(5);
            controlPanel.AddController(controller);

            Application.Run(controlPanel);
        }
    }
}
