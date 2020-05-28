using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingByAlbahariExamples
{
    public class SignallingAutoResetEvent
    {
        public static void Test()
        {
            var signal = new AutoResetEvent(false);
            var threads = new List<Thread>();

            for (int i = 0; i < 10; i++)
            {
                var temp = i;

                threads.Add(new Thread(() =>
                {
                    Console.WriteLine($"Thread {temp} is waiting for signal");
                    signal.WaitOne();
                    Thread.Sleep(200);
                    Console.WriteLine($"Thread {temp}. Signal received and disposed");
                }));
            }

            foreach (var thread in threads)
            {
                thread.Start();
            }

            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(2000);
                Console.WriteLine("signal sent");
                signal.Set();
            }

            signal.Dispose();

        }
    }
}
