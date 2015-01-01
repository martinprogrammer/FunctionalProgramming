using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalProgramming
{
    public static class PartialFunctions
    {
        public static double  CalculateDistanceIn3D(double x, double y, double z)
        {
            return Math.Sqrt(x *x + y *y + z *z);

        }

        public static void ExecutePartialFunction()
        {
            Func<double, double, double, double> fun = CalculateDistanceIn3D;
            Console.WriteLine(fun(5, 7, 19));

        }
    }
}
