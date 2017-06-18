using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTControlSystemExamples
{
    public interface IExample
    {
        void Run();
        double[] GetTime();
        double[] GetValues();
    }
}
