using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTControlSystem.Controllers
{
    public interface IController
    {
        double NextIteration(double input, double processValue, double dt);
        void Initialize(double dt);
    }
}
