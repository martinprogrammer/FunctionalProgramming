using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalProgramming
{
    public static class TuplesStuff
    {
        public static Tuple<int, string> ReturnNumberAsWord(int number)
        {
            var x = number;
            var y = "One";

            var theTuple = Tuple.Create(x, y);
            return theTuple;
        }

        public static void ExecuteReturnNumberAsWord()
        {
            var theTuple = ReturnNumberAsWord(1);
            Console.WriteLine("{0} {1}", theTuple.Item1, theTuple.Item2);
        }
    }
}
