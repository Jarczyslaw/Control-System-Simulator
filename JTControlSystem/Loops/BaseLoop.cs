using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTControlSystem
{
    public abstract class BaseLoop
    {
        protected double dt;
        protected int iteration = -1;

        public virtual void Initialize()
        {
            iteration = -1;
        }

        public double CurrentTime
        {
            get
            {
                return iteration * dt;
            }
        }
    }
}
