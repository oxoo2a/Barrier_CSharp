using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Barrier_Synchronization
{
    class Barrier
    {
        public Barrier(int n_threads)
        {
            b = new System.Threading.Barrier(n_threads);
        }

        public void Reached()
        {
            if (b.ParticipantsRemaining == 1)
                Console.WriteLine("------------------------------------------------------------");
            b.SignalAndWait();
        }

        private System.Threading.Barrier b;
    }
}
