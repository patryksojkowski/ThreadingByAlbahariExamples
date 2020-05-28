using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingByAlbahariExamples
{
    public class TaskWithResult
    {
        public static void Test()
        {

            var t = Task.Factory.StartNew(() => DownloadString("http://www.cnn.com"));
            try
            {
                var result = t.Result;
            }
            catch (AggregateException ex)
            {
                Console.WriteLine(ex.InnerException.Message);
            }
            Console.WriteLine("result queried");
        }

        static string DownloadString(string uri)
        {
            using var wc = new System.Net.WebClient();
            var str = wc.DownloadString(uri);
            throw new Exception();
            return str;
        }

    }
}
