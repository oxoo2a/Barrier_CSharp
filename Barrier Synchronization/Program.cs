using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Barrier_Synchronization
{
    class Program
    {
        static void Main(string[] args)
        {
            const int n_worker = 5;

            IBarrier barrier = new MyBarrier(n_worker);

            Worker[] w = new Worker[n_worker];
            for (int i = 0; i < n_worker; i++)
                w[i] = new Worker(i + 1,barrier);

            w[0].Join();
        }
    }
}
