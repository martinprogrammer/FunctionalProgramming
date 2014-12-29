using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FunctionalProgramming
{
    public static class AsyncStuff
    {
        public static string SlowMethod(int timeDelay)
        {
            Thread.Sleep(timeDelay);
            return "Finished";
        }

        public static void ExecuteSlowMethod()
        {
            Func<int, string> slowMethod = SlowMethod;

            IAsyncResult asyncResult = slowMethod.BeginInvoke(234, null, null);
            while (!asyncResult.IsCompleted)
            {
                Console.WriteLine(slowMethod.EndInvoke(asyncResult));

            }
                

        
        }
    }
}
