using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingByAlbahariExamples
{
    public class JoinTest
    {
        public static void TestWithJoin()
        {
            var instance = new JoinTest();
            var thread = new Thread(() => new JoinTest().Go("helper", 100));

            Console.WriteLine("helper started");
            thread.Start();

            Console.WriteLine("helper joined");
            thread.Join();

            Console.WriteLine("main ended");

        }
        public static void TestWithoutJoin()
        {
            var instance = new JoinTest();
            var thread = new Thread(() => new JoinTest().Go("helper", 100));

            Console.WriteLine("helper started");
            thread.Start();

            Console.WriteLine("main ended");
        }

        public void Go(string name, int count)
        {
            for(int i = 0; i < count; i ++)
            {
                var x = 10;
            }
            Console.WriteLine($"{name} ended");
        }
    }
}
