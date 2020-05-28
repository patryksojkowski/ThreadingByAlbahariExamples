using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingByAlbahariExamples
{
    public class OldFashionedThreadpool
    {
        public static void Test()
        {
            var function = new Func<string>(() => { Thread.Sleep(2000); return ""; });
            var cokie = function.BeginInvoke(null, null);
            var yyyy = function.EndInvoke(cokie);
        }
    }
}
