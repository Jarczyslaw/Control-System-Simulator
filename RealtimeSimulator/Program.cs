using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Globalization;
using System.Windows.Forms;
using JTControlSystem;

namespace RealtimeSimulator
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

            // create simulator with plant and regulator
            Simulator simulator = new Simulator(0.001);
            simulator.AddRegulator(new PID(3.0255, 2.7713, 0.69893));
            simulator.AddSystem(new ContinousSystem(new SecondOrder(0d, 0d, 2.0, 1.0, 0.5), 0d, new SolverEuler()));
            simulator.Init();

            // create controller with simulator
            Controller controller = new Controller(simulator);
            // create control panel with controller and controlPanelConfig
            MainForm controlPanel = new MainForm(
                controller,
                new RealtimeSimulatorConfig()
                {
                    stepsPerUpdate = 50,
                    inputMin = 0.0,
                    inputMax = 2.0,
                    setValueMin = 0.0,
                    setValueMax = 2.0,
                    outputChartConfig = new ChartConfig("output value", 0.0, 3.0),
                    inputChartConfig = new ChartConfig("input value", 0.0, 2.0),
                    controlChartConfig = new ChartConfig("control value", -2.0, 2.0)
                });
            // optionally add visualization form
            //controlPanel.AddVisualization(new CustomVisualization());

            Application.Run(controlPanel);
        }
    }
}
