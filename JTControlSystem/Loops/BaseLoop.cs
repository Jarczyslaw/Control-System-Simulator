using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTControlSystem
{
    public abstract class BaseLoop
    {
        public double Dt { get; protected set; } = -1d;
        protected int iteration = -1;

        public double CurrentTime
        {
            get { return iteration * Dt; }
        }

        public virtual void Initialize()
        {
            iteration = 0;
        }

        public abstract void NextIteration(double input);

    }
}
