using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingByAlbahariExamples
{
    // all threads share same event instance and go when signal is set at once.
    public class SignalingManualResetEvent
    {
        public static void Test()
        {
            var signal = new ManualResetEvent(false);
            var threads = new List<Thread>();

            for(int i = 0; i < 10; i++)
            {
                threads.Add(new Thread(() =>
                {
                    Console.WriteLine($"Thread {i} is waiting for signal");
                    signal.WaitOne();
                    Console.WriteLine($"Thread {i}. Signal received and disposed");
                }));
            }

            foreach(var thread in threads)
            {
                thread.Start();
            }

            for(int i = 0; i < 10; i ++)
            {
                Thread.Sleep(2000);
                Console.WriteLine("signal sent");
                signal.Set();
            }

            signal.Dispose();
           
        }
    }
}
