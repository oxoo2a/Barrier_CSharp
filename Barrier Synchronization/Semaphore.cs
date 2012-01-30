using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Barrier_Synchronization
{
    /// <summary>
    /// Class <c>Semaphore</c> encapsulates the low-level synchronization primitive <c>AutoResetEvent</c>
    /// and implements the classical semaphore API with the two methods P and V as introduced by
    /// Dijkstra originally.
    /// </summary>
    public class Semaphore
    {
        public Semaphore(int initial_count, int max_count)
        {
            count = initial_count;           
        }

        public void P()
        {
            Monitor.Enter(this);
            count--;
            if (count < 0)
                Monitor.Wait(this);
            Monitor.Exit(this);
        }

        public void V()
        {
            Monitor.Enter(this);
            count++;
            if (count <= 0)
                Monitor.Pulse(this);
            Monitor.Exit(this);
        }

        private int count;
    }

}
