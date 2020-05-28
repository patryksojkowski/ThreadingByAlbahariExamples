using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingByAlbahariExamples
{
    public class JoinSelflock
    {
        public static void Test()
        {
            Console.WriteLine("So idea behind this code is to force main thread to wait until itself is ended, which will never happen. This code should never make it to end.");
            var thread = Thread.CurrentThread;
            thread.Join();
        }
    }
}
