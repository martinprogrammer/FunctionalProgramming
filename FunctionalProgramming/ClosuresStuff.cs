using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalProgramming
{
    public static class ClosuresStuff
    {

        static int i = 0;
        public static void ExecuteClosures()
        {
            //Func<int, int> something = ClosuresStuff.Closures();
            //var somethingElse = ClosuresStuff.Closures();

            //something(50);
            //something(70);

           //var x = ActionSomething("Add");
           //x();
           //x = ActionSomething("Print");
           //x();
           //x= ActionSomething("Subtract");
           //x();

           //x = ActionSomething("Subtract");
           //x();
           // x= ActionSomething("Print");
           // x();

            var tuples = GetActionsBack();
            tuples.Item1();
            tuples.Item1();
            tuples.Item1();
            tuples.Item3();
            tuples.Item1();
            tuples.Item1();
         
            tuples.Item1();
            tuples.Item2();
            tuples.Item3();

        }

        public static Func<int, int> Closures()
        {
            var i = 15;

            Func<int, int> theFunc = delegate(int x)
            {
                i += x;
                Console.WriteLine(i);
                return i;
            };


            return theFunc;
        }

        public static Action ActionSomething(string actionName)
        {
           Action theAction = ()=> Console.Write("Hello");
            

            switch (actionName)
            {
                case "Add" :
                     theAction = () => i += 1;
                    break;

                case "Subtract" :
                     theAction = () => i -= 1;
                    break;
                case "Print" :
                     theAction = () => Console.WriteLine(i);
                    break;
              
            }

            return theAction;

        }

        public static Tuple<Action, Action, Action> GetActionsBack()
        {
            Action Add = () => i += 1;
            Action Subtract = () => i -= 1;
            Action Print = () => Console.WriteLine(i);

            return Tuple.Create(Add, Subtract, Print);
        }
    }
}
