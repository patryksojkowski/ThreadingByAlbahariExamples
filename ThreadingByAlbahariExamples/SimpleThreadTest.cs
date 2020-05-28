using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingByAlbahariExamples
{
    class SimpleThreadTest
    {
        public static void Test()
        {
            Thread t = new Thread(WriteY);
            t.Start();

            for (int i = 0; i < 1000; i++) Console.Write('X');
        }

        static void WriteY()
        {
            for (var i = 0; i < 1000; i++)
            {
                Console.Write('Y');
            }
        }
    }
}
