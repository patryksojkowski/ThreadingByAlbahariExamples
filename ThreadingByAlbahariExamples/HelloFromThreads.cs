using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingByAlbahariExamples
{
    public class HelloFromThreads
    {
        public static void Test()
        {
            var t = new Thread(Hello)
            {
                Name ="first",
            };
            var t2 = new Thread(Hello)
            {
                Name ="second",
            };
            t.Start();
            t.Join();
            t2.Start();
            t2.Join();
        }

        static void Hello()
        {
            Console.WriteLine($"Hello from {Thread.CurrentThread.Name}");
        }
    }
}
