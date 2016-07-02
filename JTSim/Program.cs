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
            Tests tests = new Tests(@"D:/tests/");
            tests.DoAllTests();

            Console.ReadKey();
            /*WaveGenerator gen = new WaveGenerator();
            fw.WavesToFile(gen, 10f, 0.01f, @"D://s.txt");*/
            
            /*StepsGenerator sg = new StepsGenerator(new float[] { 1f, 3f, 8f}, new float[] { 3f, -1f, 5f});
            sg.Test(10f, @"D://step.txt");*/
        }
    }
}
