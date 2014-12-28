using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalProgramming
{
    public static class ExtensionsMethods
    {
        public static IEnumerable<T1> MapXX<T1>(this IEnumerable<T1> data, Func<T1, T1> f)
        {

            List<T1> newList = new List<T1>();
            foreach (T1 x in data)
            {
               newList.Add(f(x));
            }

            return newList;

        }
    }
}
