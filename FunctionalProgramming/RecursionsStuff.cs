using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalProgramming
{
    public static class RecursionsStuff
    {
       
        public static int ProductOfNumbers(int[] numbers)
        {

            var theProduct = 1;
            var result = numbers.ToList();
            Action<int> theAction = (int p) => theProduct = p*theProduct;
            result.ForEach(p => theAction(p));
            return theProduct;


        }

        public static double Factorial(int number)
        {
            double factorial = 1;
            while(number>1)
            {
                factorial = factorial * number;
                number--;
            }

            return factorial;
        }

        public static Func<int, int> Factorial1()
        {
            Func<int, int> factorial = null;
            factorial = p => p < 1 ? 1 : p* factorial(p - 1) ;
            return factorial;
        }

        public static Func<int,int> FactorialDelegate(int number)
        {

            
                Func<int, int> f = null;
                f = delegate(int n)
                {
                   return  n < 1 ? 1 : n * f(n - 1);

                };

                return f;
           
        }

     

        public static void ExecuteFactorialRecursion()
        {
            //Console.WriteLine(ProductOfNumbers(new[] { 6, 7, 22, 3, 5, 14 }));
            //Console.WriteLine(Factorial1(17));

            var f = Factorial1();
           
            for (int x = 0; x <10; x++)
            {
               
               Console.WriteLine(f(x));
            }

       
        }
    }
}
