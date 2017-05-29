using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTControlSystem
{
    public class ControlSystem
    {
        public int Iteration { get; private set; }
        public double Dt { get; private set; }

        public ControlSystemMode mode;

        public ControlSystem(double dt)
        {
            Dt = dt;

        }

        public ControlSystem(double dt, ControlSystemMode mode)
        {
            Dt = dt;
            this.mode = mode;
            Initialize();
        }

        public void Initialize()
        {
            Iteration = -1;
        }



    }
}
