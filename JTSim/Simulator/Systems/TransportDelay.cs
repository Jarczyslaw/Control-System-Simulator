using System;
using System.Collections.Generic;

namespace JTSim
{
    public class TransportDelay
    {
        public float h;

        private Queue<float> buffer;
        private int bufferCapacity;

        public TransportDelay(float delay, float initState, float h)
        {
            this.h = h;
            Init(delay, initState);
        }

        public float Step(float newState)
        {
            if (bufferCapacity == 0)
                return newState;
            else
            {
                buffer.Enqueue(newState);
                return buffer.Dequeue();
            }
        }

        public void Init (float delay, float initState)
        {
            bufferCapacity = Convert.ToInt32(delay / h);
            buffer = new Queue<float>(bufferCapacity);
            for (int i = 0; i < bufferCapacity; i++)
                buffer.Enqueue(initState);
        }
    }
}
