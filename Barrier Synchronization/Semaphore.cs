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
        public Semaphore(int initial_count)
        {
            count = initial_count;
            m = new Mutex();
            are = new AutoResetEvent(false);
        }

        public void P()
        {
            m.WaitOne();
            int w = --count;
            m.ReleaseMutex();
            if (w < 0) are.WaitOne();
        }

        public void V()
        {
            m.WaitOne();
            int w = ++count;
            m.ReleaseMutex();
            if (w <= 0) are.Set();
        }

        private int count;
        private Mutex m;
        private AutoResetEvent are;
    }

}
