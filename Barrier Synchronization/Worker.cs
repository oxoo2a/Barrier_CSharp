using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Barrier_Synchronization
{
    class Worker
    {
        public Worker(int id, IBarrier barrier)
        {
            this.id = id;
            this.barrier = barrier;
            r = new Random(id);
            t = new Thread(main);
            t.Start();
        }

        protected void main()
        {
            int loop = 0;
            while (true)
            {
                loop++;
                mutex.P();
                Console.Write("Worker {0}:{1}", id, loop);
                for (int i = 0; i < id; i++) Console.Write("    ");
                Console.WriteLine("/-\\");
                mutex.V();

                Thread.Sleep(1000 + r.Next(max_sleep_time));

                mutex.P();
                Console.Write("Worker {0}:{1}", id, loop);
                for (int i = 0; i < id; i++) Console.Write("    ");
                Console.WriteLine("\\-/");
                mutex.V();

                barrier.BarrierReached();
            }
        }

        public void Join()
        {
            t.Join();
        }

        private int id;
        private Thread t;
        private Random r;
        private const int max_sleep_time = 10000;
        private IBarrier barrier;
        private static Semaphore mutex = new Semaphore(1);
    }
}
