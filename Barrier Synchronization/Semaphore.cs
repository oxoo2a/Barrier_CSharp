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
            s = new System.Threading.Semaphore(initial_count, max_count);
        }

        public void P()
        {
            s.WaitOne();
        }

        public void V()
        {
            s.Release();
        }

        private System.Threading.Semaphore s;
    }

}
