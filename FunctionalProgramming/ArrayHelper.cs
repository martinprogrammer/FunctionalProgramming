using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalProgramming
{
    public class ArrayHelper<T> where T : class
    {
        public int returnArrayCount(T[] theList, Func<T, bool> predicate)
        {
            return theList.AsQueryable().Where(predicate).Count();
        }

        public int returnListCount(List<T> theList, Func<T, bool> predicate)
        {
            return theList.Where(predicate).Count();
        }

        public int returnListCountWithPredicate(List<T>theList, Predicate<T> predicate)
        {
            return theList.Count();
        }
    }
}
