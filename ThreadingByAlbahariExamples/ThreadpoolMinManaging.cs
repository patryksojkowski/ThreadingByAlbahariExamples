using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingByAlbahariExamples
{
    public class ThreadpoolMinManaging
    {
        public static async Task TestWithMinimumAsync()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            // minimum number of threads speeds up in this case since we do not have to wait for every thread to be created after timeout
            ThreadPool.SetMinThreads(200, 200);

            var tasks = new List<Task>();

            for (var i = 0; i < 100; i++)
            {
                var instance = new ThreadpoolMinManaging();
                tasks.Add(Task.Factory.StartNew(instance.Function));
            }
            await Task.WhenAll(tasks);
            watch.Stop();
            Console.WriteLine($"Done in {watch.ElapsedMilliseconds}");
        }

        public static async Task TestWithoutMinimumAsync()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            var tasks = new List<Task>();

            for (var i = 0; i < 100; i++)
            {
                var instance = new ThreadpoolMinManaging();
                tasks.Add(Task.Factory.StartNew(instance.Function));
            }
            await Task.WhenAll(tasks);
            watch.Stop();
            Console.WriteLine($"Done in {watch.ElapsedMilliseconds}");
        }

        public void Function()
        {
            Thread.Sleep(550);
            //using var wc = new System.Net.WebClient();
            //wc.DownloadString("https://www.onet.pl/").Length.ToString();
        }
    }
}
