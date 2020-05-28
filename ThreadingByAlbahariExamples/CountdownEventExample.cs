using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingByAlbahariExamples
{
    public class CountdownEventExample
    {
        private static CountdownEvent countdown = new CountdownEvent(100);
        public static void Test()
        {
            var tAdd = new Thread(() => AddCount());
            var tRemove = new Thread(() => RemoveCount());

            var tShowCount = new Thread(() => ShowCount());
            tShowCount.Start();

            tAdd.Start();
            tRemove.Start();
            countdown.Wait();
        }

        static void AddCount()
        {
            while (true)
            {
                Thread.Sleep(10);
                countdown.AddCount(25);
            }
        }

        static void RemoveCount()
        {
            while (true)
            {
                Thread.Sleep(10);
                countdown.Signal();
            }
        }

        static void ShowCount()
        {
            while (true)
            {
                Thread.Sleep(10);
                Console.Clear();
                Console.Write(countdown.CurrentCount);
            }
        }

    }
}
