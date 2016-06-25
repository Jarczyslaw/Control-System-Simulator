using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTSim
{
    class Program
    {
        static void Main(string[] args)
        {
            double h = 0.01f;
            var simulator = new Simulator(h);
            simulator.AddRegulator(new TransparentRegulator());
            //s.AddSystem(new ContinousSystem(new SecondOrder(0f, 0f), 1f, new SolverEuler()));
            //s.AddSystem(new DiscreteSystem(new DiscreteSecondOrder(0.0f, 0f), 1f));
            //s.AddSystem(new AlphaFilter(0.5f));
            //s.AddSystem(new DiscreteSystem(new AlphaFilter2(-0.5f), 1f));
            //s.AddSystem(new DiscreteSystem(new AR(-1f, -1f, -1f)));
            simulator.AddSystem(new ContinousSystem(new Test(), 0d, new SolverRK4()));
            simulator.mode = Simulator.Modes.OpenLoop;
            simulator.StepSimulation(10f);
            FileWriter fw = new FileWriter();
            fw.DataToFile(simulator.data, @"D://data.txt");

            /*WaveGenerator gen = new WaveGenerator();
            fw.WavesToFile(gen, 10f, 0.01f, @"D://s.txt");*/
            
            /*StepsGenerator sg = new StepsGenerator(new float[] { 1f, 3f, 8f}, new float[] { 3f, -1f, 5f});
            sg.Test(10f, @"D://step.txt");*/
        }
    }
}
