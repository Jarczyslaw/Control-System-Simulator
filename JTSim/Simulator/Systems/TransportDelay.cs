using System;
using System.Collections.Generic;

namespace JTSim
{
    public class TransportDelay
    {
        public double h;

        private Queue<double> buffer;
        private int bufferCapacity;

        public TransportDelay(double delay, double initState, double h)
        {
            this.h = h;
            Init(delay, initState);
        }

        public double Step(double newState)
        {
            if (bufferCapacity == 0)
                return newState;
            else
            {
                buffer.Enqueue(newState);
                return buffer.Dequeue();
            }
        }

        public void Init (double delay, double initState)
        {
            bufferCapacity = Convert.ToInt32(delay / h);
            buffer = new Queue<double>(bufferCapacity);
            for (int i = 0; i < bufferCapacity; i++)
                buffer.Enqueue(initState);
        }
    }
}
