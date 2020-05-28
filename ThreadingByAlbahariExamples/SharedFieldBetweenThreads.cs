using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingByAlbahariExamples
{
    public class SharedFieldBetweenThreads
    {
        private bool done;
        private int number = 0;

        static readonly object locker = new object();

        public static void Test()
        {
            var instance = new SharedFieldBetweenThreads();

            new Thread(instance.Go)
            {
                Name = "helper",
            }.Start();

            instance.Go();
        }
        
        public static void TestWithLock()
        {
            var instance = new SharedFieldBetweenThreads();

            new Thread(instance.SafeGo)
            {
                Name = "helper",
            }.Start();

            instance.SafeGo();
        }

        void Go()
        {
            if (!done)
            {
                number++;
                for (int i = 0; i < 25000; i++)
                {
                }
                if (number == 2)
                {
                    Console.WriteLine("It happened!");
                }
                done = true;
            }
        }

        void SafeGo()
        {
            lock (locker)
            {
                if (!done)
                {
                    number++;
                    for (int i = 0; i < 25000; i++)
                    {
                        //
                    }
                    if (number == 2)
                    {
                        Console.WriteLine("It happened!");
                    }
                    done = true;
                }
            }
        }


    }
}
