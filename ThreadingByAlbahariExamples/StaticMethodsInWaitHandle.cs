using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingByAlbahariExamples
{
    public class StaticMethodsInWaitHandle
    {
        private static readonly AutoResetEvent _autoWh1 = new AutoResetEvent(false);
        private static readonly AutoResetEvent _autoWh2 = new AutoResetEvent(false);

        public static void TestWaitAll()
        {
            var t = new Thread(FunctionWaitAll)
            {
                IsBackground = true,
            };
            t.Start();
            Thread.Sleep(2000);

            _autoWh1.Set();
            _autoWh2.Set();
        }


        static void FunctionWaitAll()
        {
            Console.WriteLine("Wait started");
            WaitHandle.WaitAll(new WaitHandle[] { _autoWh1, _autoWh2 });
            Console.WriteLine("Wait ended");
        }
        public static void TestWaitAny()
        {
            var t = new Thread(FunctionWaitAny)
            {
                IsBackground = true,
            };
            t.Start();
            Thread.Sleep(2000);

            Console.WriteLine("wh1 set");
            _autoWh1.Set();
            Thread.Sleep(2000);
            Console.WriteLine("wh2 set");
            _autoWh2.Set();
        }


        static void FunctionWaitAny()
        {
            Console.WriteLine("Wait started");
            WaitHandle.WaitAny(new WaitHandle[] { _autoWh1, _autoWh2 });
            Console.WriteLine("Wait ended");
        }
    }
}
