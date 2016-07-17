using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JVectors
{
    class Program
    {
        static void Main(string[] args)
        {


            var m1 = new JMatrix(new double[,] { { 1.0, 2.0 }, { 3.0, 4.0 }, { 5.0, 6.0 } });
            var m2 = new JMatrix(new double[,] { { 2.0, 3.0 }, { 4.0, 5.0 }, { 6.0, 7.0 } });
            var m3 = new JMatrix(new double[,] { { 1.0, 2.0 }, { 3.0, 4.0 } });
            var v1 = new JVector(new double[] { 2.0, 1.0 });

            Console.WriteLine((new JMatrix(new double[,] { { 1.0, 2.0 }, { 3.0, 4.0 } })).Inv());

            Console.ReadKey();
        }
    }
}
