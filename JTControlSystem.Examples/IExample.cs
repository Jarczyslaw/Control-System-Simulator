using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTControlSystem.Examples
{
    public interface IExample
    {
        void Run();
        double[] GetTime();
        double[] GetValues();
    }
}
