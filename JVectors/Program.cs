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


            var m1 = new JMatrix(new double[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } });
            var m2 = new JMatrix(new double[,] { { 2, 3 }, { 4, 5 }, { 6, 7 } });
            var m3 = new JMatrix(new double[,] { { 1, 2 }, { 3, 4 } });
            var v1 = new JVector(new double[] { 2, 1 });

            Console.WriteLine((new JMatrix(new double[,] { { 1, 2 }, { 3, 4 } })).Inv());

            Console.ReadKey();
        }
    }
}
