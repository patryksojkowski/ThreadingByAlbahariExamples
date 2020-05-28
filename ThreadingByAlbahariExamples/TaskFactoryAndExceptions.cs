using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingByAlbahariExamples
{
    public class TaskFactoryAndExceptions
    {
        public static void TestWithWait()
        {
            Console.WriteLine("Starting task with wait...");
            var t = Task.Factory.StartNew(() => Function("exception thrown from waiting version"));
            t.Wait(); // with wait exception will be rethrown to higher level
            if (t.IsCompleted)
            {
                Console.WriteLine("task completed");
            }
            else
            {
                Console.WriteLine("task not completed in time");
            }
        }

        public static void TestWithoutWait()
        {
            Console.WriteLine("Starting task without wait...");
            var t = Task.Factory.StartNew(() => Function("exception thrown from not waiting version"));
            if (t.IsCompleted)
            {
                Console.WriteLine("task completed");
            }
            else
            {
                Console.WriteLine("task not completed in time");
            }
        }

        static void Function(string message)
        {
            Thread.Sleep(2000);
            for(var i = 0; i < 1000000; i++)
            {
            }
            Console.WriteLine("doing my jooob");
            throw new Exception(message);
        }
    }
}
