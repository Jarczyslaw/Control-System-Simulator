using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using JMath;

namespace JTSim
{
    public class Tests
    {
        private string directory;
        private Simulator simulator;
        private FileWriter fileWriter;
        private Stopwatch stopwatch = new Stopwatch();

        public Tests(string directory)
        {
            this.directory = directory;
            Directory.CreateDirectory(directory);

            simulator = new Simulator(0.001);
            fileWriter = new FileWriter();
        }

        public void Test1(string fileName)
        {
            simulator.AddRegulator(new TransparentRegulator());
            simulator.AddSystem(new ContinousSystem(new FirstOrder(0d), 0d, new SolverRK4()));
            simulator.feedbackEnabled = false;
            simulator.Init();
            simulator.StepSimulation(10f);

            fileWriter.SimulatorDataToFile(simulator, directory + fileName);
        }

        public void Test2(string fileName)
        {
            simulator.AddRegulator(new TransparentRegulator());
            simulator.AddSystem(new ContinousSystem(new SecondOrder(0d, 0d), 0d, new SolverRK4()));
            simulator.feedbackEnabled = false;
            simulator.Init();
            simulator.StepSimulation(10d);

            fileWriter.SimulatorDataToFile(simulator, directory + fileName);
        }

        public void Test3(string fileName)
        {
            simulator.AddRegulator(new PID(1.09, 3.16, 0.12));
            simulator.AddSystem(new ContinousSystem(new FirstOrder(0.5d, 2.0, 3.0), 1d, new SolverRK4()));
            simulator.feedbackEnabled = true;
            simulator.Init();
            simulator.StepSimulation(20f);

            fileWriter.SimulatorDataToFile(simulator, directory + fileName);
        }

        public void Test4(string fileName)
        {
            simulator.AddRegulator(new TransparentRegulator());
            simulator.AddSystem(new DiscreteSystem(new DiscreteSecondOrder(0.0, 0.0), 2d));
            simulator.feedbackEnabled = false;
            simulator.Init();
            simulator.StepSimulation(10.0);

            fileWriter.SimulatorDataToFile(simulator, directory + fileName);
        }

        public void Test5(string fileName)
        {
            WavesGenerator wave = new WavesGenerator(0.5, 3.0, 1.0);
            var data = wave.GetWaves(10.0, 0.1);

            fileWriter.DataToFile(data, directory + fileName);
        }

        public void Test6(string fileName)
        {
            StepsGenerator steps = new StepsGenerator(
                new double[] { 0.0, 5.0, 8.0, 14.0 },
                new double[] { 1.0, -3.0, 2.0, 0.0 });
            var data = steps.GetSteps(20.0, 0.1);

            fileWriter.DataToFile(data, directory + fileName);
        }

        public void Test7(string fileName)
        {
            simulator.AddRegulator(new TransparentRegulator());

            var A = new JMatrix(new double[,] { { 0.0, 1.0 }, { -2.0, -3.0 } });
            var B = new JVector(new double[] { 0.0, 4.0 });
            var C = new JVector(new double[] { 1.0, 0.0 });
            var D = 0d;
            var initState = new JVector(new double[] { 1.0, -1.0 });

            simulator.AddSystem(new ContinousSystem(new StateSpaceModel(A, B, C, D, initState), 0d, new SolverRK4()));
            simulator.feedbackEnabled = false;
            simulator.Init();
            simulator.StepSimulation(10f);

            fileWriter.SimulatorDataToFile(simulator, directory + fileName);
        }

        public void Test8(string fileName)
        {
            simulator.AddRegulator(new PID(4.2382, 1.5278, 0.1868));

            var A = new JMatrix(new double[,] { { 0.0, 1.0 }, { -2.0, -3.0 } });
            var B = new JVector(new double[] { 0.0, 4.0 });
            var C = new JVector(new double[] { 1.0, 0.0 });
            var D = 0d;
            var initState = new JVector(new double[] { 1.0, 0.0 });

            simulator.AddSystem(new ContinousSystem(new StateSpaceModel(A, B, C, D, initState), 0d, new SolverRK4()));
            simulator.feedbackEnabled = true;
            simulator.Init();

            StepsGenerator steps = new StepsGenerator(new double[] { 0.0, 5.0, 10.0 }, new double[] { 2.0, -2.0, 2.0 });
            simulator.SignalSimulation(15.0, steps);

            fileWriter.SimulatorDataToFile(simulator, directory + fileName);
        }

        public void Test9(string fileName)
        {
            simulator.AddRegulator(new TransparentRegulator());
            simulator.AddSystem(new ContinousSystem(new TransferFunction(new double[] { 2.0, 6.0 }, new double[] { 2.0, 4.0, 2.0, 2.0 }), new SolverEuler()));
            simulator.feedbackEnabled = false;
            simulator.Init();
            simulator.StepSimulation(10.0);

            fileWriter.SimulatorDataToFile(simulator, directory + fileName);
        }

        public void DoAllTests()
        {
            foreach (MethodInfo method in this.GetType().GetMethods())
            {
                string methodName = method.Name.ToLower();
                if (methodName.StartsWith("test"))
                {
                    stopwatch.Reset();
                    stopwatch.Start();
                    method.Invoke(this, new object[] { methodName + ".txt" });
                    stopwatch.Stop();
                    Console.WriteLine("Test: " + method.Name + " done in: " + stopwatch.ElapsedMilliseconds + "ms");
                }
            }
        }
    }
}
