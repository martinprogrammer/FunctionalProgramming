using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalProgramming
{
    public static class CompositeStuff
    {

        public static void ExecuteCompositeFunction()
        {
            Func<int, double> xy = (x) => Convert.ToDouble(x *2);
            Func<double, decimal> yz=(x) => Convert.ToDecimal(x /3);
            Func<int,decimal> result = CompositeStuff.ConvertFromXtoZ(xy,yz);
            var theResultType = result(33).GetType();


            Console.WriteLine(result(23432));
        }
        public static Func<X, Z> ConvertFromXtoZ<X, Y, Z>(Func<X,Y> xy, Func<Y,Z> yz)
        {
            Func<X,Z> xToz = (p)=> yz(xy(p));
            return p=>yz(xy(p));
        }
    }
}
