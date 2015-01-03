using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalProgramming
{
    public static class CurryingStuff
    {
        public static Func<double, double, double, double> Currying()
        {
            return (x, y, z) => x * x + y * y + z * z;
            //Console.WriteLine(Distance3D(23, 43, 23));
        }

        public static Func<T1, Func<T2, Func<T3, TResult>>> Curry<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> funct, T1 x, T2 y, T3 z)
        {
            return a =>b =>c => funct(a, b, c);
        }

        public static void ExecuteCurrying()
        {
            Func<double, double, double, double> Schmack = (x, y, z) => x * x + y * y + z * z;
            var curriedDistance =Curry<double, double, double, double>(Schmack,34, 11, 2);
          
            Console.WriteLine(curriedDistance(3)(4));
           
            
        }
    }
}
