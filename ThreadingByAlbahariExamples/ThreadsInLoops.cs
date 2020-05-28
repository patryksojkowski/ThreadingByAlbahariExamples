using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingByAlbahariExamples
{
    public class ThreadsInLoops
    {
        public static void TestWithErrors()
        {
            for(var i = 0; i < 10; i++)
            {
                new Thread(() => Console.Write(i)).Start();
            }
        }
        public static void TestWithoutErrors()
        {
            for(var i = 0; i < 10; i++)
            {
                var temp = i;
                new Thread(() => Console.Write(temp)).Start();
            }
        }
    }
}
