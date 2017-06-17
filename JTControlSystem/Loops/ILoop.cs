using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTControlSystem
{
    public interface ILoop
    {
        void NextIteration(double input, double time, double dt);
        void Initialize(double dt);
    }
}
