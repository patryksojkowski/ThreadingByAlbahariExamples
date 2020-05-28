using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingByAlbahariExamples
{
    public class DeadlockExample
    {
        private static readonly object A = new object();
        private static readonly object B = new object();

        public static void Test()
        {
            var t1 = new Thread(() => Function1());
            var t2 = new Thread(() => Function2());

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();
        }

        static void Function1()
        {
            lock (A)
            {
                Console.WriteLine("Function1 blocks A");

                Thread.Sleep(1000);
                Console.WriteLine("Function1 is waiting for B.");

                lock (B)
                {

                }
            }
        }

        static void Function2()
        {
            lock (B)
            {
                Console.WriteLine("Function2 blocks B");

                Thread.Sleep(1000);
                Console.WriteLine("Function2 is waiting for A.");
                lock (A)
                {

                }
            }
        }
    }
}
