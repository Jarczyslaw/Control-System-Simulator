using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JVector
{
    class Program
    {
        static void Main(string[] args)
        {
            JVector v = new JVector(new double[] { 1,2,3,4,5 });
            Console.WriteLine(v.Inv().ToString());

            Console.ReadKey();
        }
    }
}
