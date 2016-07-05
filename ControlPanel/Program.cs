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

            // create simulator with plant and regulator
            double h = 0.0001d;
            Simulator simulator = new Simulator(h);
            simulator.AddRegulator(new P());
            simulator.AddSystem(new ContinousSystem(new SecondOrder(0d, 0d), 0d, new SolverEuler()));
            simulator.Init();

            // create controller with simulator
            Controller controller = new Controller(simulator);
            // create control panel with controller and controlPanelConfig
            ControlPanel controlPanel = new ControlPanel(
                controller,
                new ControlPanelConfig()
                {
                    stepsPerUpdate = 500,
                    inputMin = 0,
                    inputMax = 2,
                    setValueMin = 0,
                    setValueMax = 2,
                    outputChartConfig = new ChartConfig("output value", 0, 3),
                    inputChartConfig = new ChartConfig("input value", 0, 2),
                    controlChartConfig = new ChartConfig("control value", 0, 2)
                });
            // optionally add visualization form
            controlPanel.AddVisualization(new CustomVisualization());

            Application.Run(controlPanel);
        }
    }
}
