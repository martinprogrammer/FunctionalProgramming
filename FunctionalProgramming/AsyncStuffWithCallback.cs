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

            IAsyncResult result = slowThing.BeginInvoke(343, p =>
            {
                var async = (AsyncResult)p;
                var fn = (Func<int, string>)async.AsyncDelegate;
                var res = fn.EndInvoke(p);
                Console.WriteLine(res);
            }, null);

        }
    }
}
