using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace FunctionalProgramming
{
    public static class Currying1
    {
        public static Func<T1, Func<T2, Func<T3, TResult>>> Curry<T1,T2,T3,TResult>(this Func<T1,T2,T3,TResult> funct, T1 t1, T2 t2, T3 t3)
        {
            return a=>b=>c=> funct(a,b,c);
        }

        public static void ExecuteCurrying1()
        {
            //Func<double, double> myFunc =x => x;
            //Console.WriteLine(myFunc(5).Adding(5).Adding(7));

            var theSampleList = Enumerable.Range(1, 1000);
            //var sliceOfSampleList = theSampleList.Skip(100).Take(50);

            var stopWatch = new Stopwatch();
            stopWatch.Start();
            Parallel.ForEach(theSampleList.Slice(5), s =>
                {
                    Parallel.ForEach(s, item =>
                        {
                            Console.WriteLine(item);
                        });
                });

            Console.WriteLine("Elapsed {0}", stopWatch.ElapsedMilliseconds);
            
            //var theSliced = theSampleList.Slice(6);

            stopWatch.Restart();
            foreach (var x in theSampleList.Slice(6))
            {
                foreach(var y in x)
                {
                    Console.WriteLine(y);
                }
                
               
            }

            Console.WriteLine("Elapsed {0}", stopWatch.ElapsedMilliseconds);
            

           


        }

        public static double Adding(this double input,  double d)
        {
            return input+d;
        }

        public static IEnumerable<IEnumerable<T>> Slice<T>(this IEnumerable<T> collection, int x)
        {
            List<List<T>> theList = new List<List<T>>();
            
           
            
            if (collection.Count() == 0) throw new ApplicationException("The collection is empty");
            if (collection.Count() <= x)
            {
               // theList.AddRange(collection.AsEnumerable());
                return theList;
            }


            int theCount = collection.Count();
            
            for(int i = 0;  i<theCount/x; i++)
            {
                theList.Add(collection.Skip(i * x).Take(x).ToList());
                //theList.ToList().Insert(0, collection.Skip(i*x).Take(x).ToList());
            }
            
            if(theCount.HasReminder(x))
            {
                var toInsert = collection.Skip(theCount- theCount.ReturnReminder(x)).Take(x).ToList();
                theList.Add(toInsert);
                //theList.AddRange(toInsert);
            }


            return theList;

        }

        public static bool HasReminder(this int theInt, int toDivideBy)
        {
            return theInt.ReturnReminder(toDivideBy) >0;
        }

        public static int ReturnReminder(this int theInt, int toDivideBy)
        {
            return theInt % toDivideBy;
        }
    }
}
