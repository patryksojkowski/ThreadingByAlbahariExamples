using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingByAlbahariExamples
{
    public class ImmutablesAndThreadSafe
    {

        public static void Test()
        {
            var progress1 = new ProgressStatus(10, "first status");
            var t1 = new Thread(() => PlayWithStatus(progress1));
            var t2 = new Thread(() => DontPlayWithStatus(progress1));
            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();
        }

        private static void PlayWithStatus(ProgressStatus status)
        {
            Thread.Sleep(1000);
            var timer = System.Diagnostics.Stopwatch.StartNew();
            while (timer.ElapsedMilliseconds < 1000)
            {
                var st = status.Modify(22, "first status modified");
            }
        }

        private static void DontPlayWithStatus(ProgressStatus status)
        {
            var timer = System.Diagnostics.Stopwatch.StartNew();
            var i = 0;
            while(timer.ElapsedMilliseconds < 2000)
            {
                status.ReadPercent();
                i++;
                if (i == 200000)
                {
                    i = 0;
                    Console.WriteLine(status.ReadPercent());
                }
            }
        }


        private class ProgressStatus
        {
            public readonly int PercentComplete;
            public readonly string StatusMessage;

            readonly object _statusLocker = new object();
            private ProgressStatus _status;


            public ProgressStatus(int percentComplete, string statusMessage)
            {
                PercentComplete = percentComplete;
                StatusMessage = statusMessage;
                _status = this;
            }

            public ProgressStatus Modify(int percentComplete, string statusMessage)
            {
                var status = new ProgressStatus(percentComplete, statusMessage);

                lock (_statusLocker) _status = status;

                return status;
            }

            public int ReadPercent()
            {
                ProgressStatus statusCopy;

                lock (_statusLocker) statusCopy = _status;

                return statusCopy.PercentComplete;
            }
        }
    }
}
