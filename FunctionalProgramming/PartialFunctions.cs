using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalProgramming
{
    public static class PartialFunctions
    {
        public static double CalculateDistanceIn3D(double x, double y, double z)
        {
            return Math.Sqrt(x * x + y * y + z * z);

        }

      
        public static Func<T1, T2, TResult> SetDefaultZ<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> funct, T3 theDefault)
        {
            //public static Func<T1,T2,TResult> - that's the signature of the extension method - It takes 2 arguments instead of 3
            //this Func<t1, t2, t3, TResult> - the signature of the CalculateDistanceIn3D that the method extends
            // T3 theDefault - the only argument that the SetDefault accepts in order to return it in the Func - (x,y)=> funct(x,y,theDefault)
            return (x,y) => funct(x,y, theDefault);
        }

        public static Func<T1, TResult> SetDefaultYandZ<T1, T2, T3, TResult>(this Func<T1, T2,T3,TResult> funct, T2 defaultY, T3 defaultZ)
        {
            return (x) => funct(x, defaultY, defaultZ);
        }

        public static void ExecutePartialFunction()
        {
            Func<double, double, double, double> fun = CalculateDistanceIn3D;
            Console.WriteLine(fun(5, 7, 19));

            Func<double, double, double> distance2D = fun.SetDefaultZ(0);
            Func<double, double> distance = fun.SetDefaultYandZ(0,5);

            Console.WriteLine(distance2D(7, 3));
            Console.WriteLine(distance(18));
        }
    }
}
