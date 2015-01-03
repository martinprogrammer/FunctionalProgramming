using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Func<double, double> myFunc =x => x;
            Console.WriteLine(myFunc(5).Adding(5).Adding(7));


        }

        public static double Adding(this double input,  double d)
        {
            return input+d;
        }

        public static IEnumerable<IEnumerable<T>> Slice<T>(IEnumerable<T> collection, int x)
        {
            IEnumerable<IEnumerable<T>> theList = new List<List<T>>();
            
            if (collection.Count() == 0) throw new ApplicationException("The collection is empty");
            if (collection.Count() <= x)
            {
                theList.ToList().Insert(0, collection);
                return theList;
            }

            theList.ToList().Insert(0, collection.Skip(skippy).Take(x));

            //Func<int, IEnumerable<T>, IEnumerable<T>> getX = delegate(int num, IEnumerable<T> y){
            //    return y.
            //}
         
        }
    }
}
