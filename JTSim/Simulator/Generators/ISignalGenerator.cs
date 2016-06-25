using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTSim
{
    public interface ISignalGenerator
    {
        double GetSample(double t);
    }
}
