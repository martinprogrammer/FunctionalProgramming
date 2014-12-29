using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FunctionalProgramming
{
    public static class AsyncStuffWithCallback
    {
        public static string SlowThing(int timeout)
        {
            Thread.Sleep(timeout);
            return "Hello";
        }

        public static void ExecuteSlowThing()
        {
            Func<int, string> slowThing = SlowThing;

            IAsyncResult result = slowThing.BeginInvoke(2231, async =>
            {
                var asy = (AsyncResult)async;
                var fn = (Func<int, string>)asy.AsyncDelegate;
                string res = fn.EndInvoke(asy);
                Console.WriteLine("{0}", res);
            }, null);

        }
    }
}
