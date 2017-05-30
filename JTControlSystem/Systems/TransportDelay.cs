using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTControlSystem.Systems
{
    public class TransportDelay
    {
        public double dt;

        private Queue<double> buffer;
        private int bufferCapacity;

        public TransportDelay(double delay, double initState, double dt)
        {
            this.dt = dt;
            Init(delay, initState);
        }

        public double NextStep(double newState)
        {
            if (bufferCapacity == 0)
                return newState;
            else
            {
                buffer.Enqueue(newState);
                return buffer.Dequeue();
            }
        }

        public void Init(double delay, double initState)
        {
            bufferCapacity = Convert.ToInt32(delay / dt);
            buffer = new Queue<double>(bufferCapacity);
            for (int i = 0; i < bufferCapacity; i++)
                buffer.Enqueue(initState);
        }
    }
}
