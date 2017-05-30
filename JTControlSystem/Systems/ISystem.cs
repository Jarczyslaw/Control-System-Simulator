using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTControlSystem.Systems
{
    public interface ISystem
    {
        double GetOutput(double input, double time, double dt);
        double Initialize(double dt);
    }
}
