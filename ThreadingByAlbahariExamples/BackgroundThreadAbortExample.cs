using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingByAlbahariExamples
{
    public class BackgroundThreadAbortExample
    {
        public static void TestInForeground()
        {
            var t = new Thread(Function)
            {
                Name = "helper thread",
                //IsBackground = false, // redundant, its false by default
            };
            t.Start();
            Console.WriteLine("helper thread called");
            Console.WriteLine("waits for helper to end since its Foreground thread");
        }

        public static void TestInBackground()
        {
            var t = new Thread(Function)
            {
                Name = "helper thread",
                IsBackground = true,
            };
            t.Start();
            Console.WriteLine("helper thread called");
            Console.WriteLine("doesnt wait for helper to end since its Background thread");

        }

        static void Function()
        {
            Thread.Sleep(5000);
            Console.WriteLine("helper ended");
        }
    }
}
