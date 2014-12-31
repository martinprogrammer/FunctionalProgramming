using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FunctionalProgramming
{
    public static class CachingWithClosures
    {
        public static Func<T> Cache<T> (this Func<T> f, int cacheIntervale)
        {
            var cachedValue = f();
            //Console.WriteLine(cachedValue);
            var timeCached = DateTime.Now;
            Func<T> cachedFunction = () =>
            {
                if ((DateTime.Now - timeCached).Seconds >= cacheIntervale)
                {
                    Console.WriteLine("still within limits - time left {0}", (DateTime.Now - timeCached).Seconds);
                    timeCached = DateTime.Now;
                    cachedValue = f();
                };
                Thread.Sleep(20);
                Console.WriteLine("still within limits - time left {0}", (DateTime.Now - timeCached).Seconds);
                return cachedValue;
            };

            return cachedFunction;

           
        }

        public static void ExecuteCache()
        {
            var currentTime = DateTime.Now;
            Random m = new Random();
            while ((DateTime.Now - currentTime).Seconds <= 50)
            {
                //Thread.Sleep(1000);
                Func<int> theFunc = delegate(){
                    var nextNumber =  m.Next();
                    return nextNumber;
                };

                var cached = theFunc.Cache(5);
                //Console.WriteLine(theFunc());
                for (int i = 0; i < 200; i++)
                    Console.WriteLine(cached());
            }
        }
    }
}
