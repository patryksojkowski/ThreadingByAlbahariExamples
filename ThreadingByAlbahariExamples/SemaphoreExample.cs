using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingByAlbahariExamples
{
    public class SemaphoreExample
    {
        private static readonly SemaphoreSlim _sem = new SemaphoreSlim(3);
        public static void Test()
        {
            for (int i = 1; i <= 5; i++)
            {
                new Thread(() => Enter(i.ToString())).Start();
            }
        }


        static void Enter(string name)
        {
            Thread.Sleep(1000);
            Console.WriteLine($"{name} wants to enter");
            _sem.Wait();

            Console.WriteLine($"{name} is in.");
            Thread.Sleep(3000);

            Console.WriteLine($"{name} is leaving.");
            _sem.Release();
        }

    }
}
