using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ControlPanel
{
    public class InterlockedBool
    {
        private long value = 0L;

        public InterlockedBool(bool val)
        {
            Set(val);
        }

        public void Set(bool val)
        {
            if (val)
                Interlocked.Exchange(ref value, 1L);
            else
                Interlocked.Exchange(ref value, 0L);
        }

        public bool Get()
        {
            return Interlocked.Read(ref value) == 1L;
        }
    }
}
