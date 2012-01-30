using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Barrier_Synchronization
{
    interface IBarrier
    {
        void BarrierReached();
    }

    class Barrier : IBarrier
    {
        public Barrier(int n_threads)
        {
            b = new System.Threading.Barrier(n_threads);
        }

        public void BarrierReached()
        {
            if (b.ParticipantsRemaining == 1)
                Console.WriteLine("------------------------------------------------------------");
            b.SignalAndWait();
        }

        private System.Threading.Barrier b;
    }

    class MyBarrier : IBarrier
    {
        public MyBarrier(int n_threads)
        {
            this.n_threads = n_threads;
            queue = new Semaphore(0, n_threads);
        }

        public void BarrierReached()
        {
            mutex.P();
            n_reached++;
            if (n_reached < n_threads)
            {
                mutex.V();
                queue.P();
            }
            else
            {
                Console.WriteLine("------------------------------------------------------------");
                while (--n_reached > 0)
                    queue.V();
                mutex.V();
            }
        }

        private Semaphore mutex = new Semaphore(1,1);
        private Semaphore queue;
        private int n_reached = 0;
        private int n_threads;
    }
}
