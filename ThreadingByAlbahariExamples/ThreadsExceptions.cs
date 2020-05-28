using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingByAlbahariExamples
{
    public class ThreadsExceptions
    {
        public static void UnhandledExceptionTest()
        {
            try
            {
                var t = new Thread(Function);
                t.Start();
            }
            catch
            {
                Console.WriteLine("exception catched");
            }
        }

        public static void HandledExceptionTest()
        {
            var t = new Thread(FunctionWithExceptionHandling);
            t.Start();
        }

        static void Function()
        {
            throw null;
        }

        static void FunctionWithExceptionHandling()
        {
            try
            {
                throw null;
            }
            catch
            {

            }
        }
    }
}
