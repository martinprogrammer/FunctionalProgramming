using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalProgramming
{
    class Program
    {
        delegate void MyDelegate(string x);
        delegate string f(string x);
        static List<Book> books = new List<Book>();
        static Book[] bookies;
        static ArrayHelper<Book> arrayHelper = new ArrayHelper<Book>();

        static void Hip(string x)
        {
            Console.WriteLine(x + " through Hip");
        }

        static void InitializeArray()
        {
            bookies = new[]{
                 new Book
            {
                Author = "Mark Twain",
                Name = "Tom Sawyer"
            },
            new Book
            {
                Author = "Ivo Andric",
                Name = "Na Drini Cuprija"
            },
            new Book
            {
                Author = "Dostoyevski",
                Name = "Idiot"
            }};
        }


        static void InitializeList()
        {
            books.Add(new Book
            {
                Author = "Mark Twain",
                Name = "Tom Sawyer"
            });

            books.Add(new Book
            {
                Author = "Ivo Andric",
                Name = "Na Drini Cuprija"
            });

            books.Add(new Book
            {
                Author = "Dostoyevski",
                Name = "Idiot"
            });

        }

       
        static void Main()
        {
            //InitializeCollections();

            //GetGenericListCount();
            //GetGenericArrayCount();
            //GetGenericListCountWithPredicate();
            //AddingRemovingDelegates();

           // int[] numbers = new[] { 5, 23, 33, 78, 99, 4 };

           // var numbersList = numbers.ToList();

           //// var reMapped = numbers.MapXX<int>(delegate(int x) { return x * 2; });

           // string[] words = new[] { "happy", "sad", "inbetween", "exstatic" };
           // var wordsList = words.ToList();
           // var reMapped = words.MapXX<string>(delegate(string x) { return x + " " + "Hello sunshine"; });

           // //var reMapped = numbers.MapXX<int>(this, delegate(int x) { return x * 2; });

           // //var reMapped = numbers.Select(p => p * 2);


           // reMapped.ToList().ForEach(p => Console.WriteLine(p));
           // CompositeStuff.ExecuteCompositeFunction();

           //AsyncStuffWithCallback.ExecuteSlowThing();

            //TuplesStuff.ExecuteReturnNumberAsWord();

           // ClosuresStuff.ExecuteClosures();

            //CachingWithClosures.ExecuteCache();
            //RecursionsStuff.ExecuteFactorialRecursion();

            PartialFunctions.ExecutePartialFunction();


            Console.Read();
        }

        private static void InitializeCollections()
        {
            InitializeArray();
            InitializeList();
        }

        private static string Hello(string name)
        {

            Console.WriteLine("Hello " + name);
            return "Done";
        }
        private static string Goodbye(string name)
        {
            Console.WriteLine("Goodbye " + name);
            return "Done";
        }

        private static void AddingRemovingDelegates()
        {
            Func<string, string> myString = delegate(string x)
            {
                return "Hello " + x;
            };

            myString += delegate(string x) { return "Goodbye " + x; };


            Func<string, string> action = delegate(string x)
            {
                Console.WriteLine();
                return "Greetings";

            };

            Func<string, string> hello = Hello;
            Func<string, string> goodbye = Goodbye;
            action += Hello;
            action += Goodbye;
            action += delegate(string x) { return String.Format("this is delegate - {0}", x); };


            action.GetInvocationList().ToList().ForEach(p => Console.WriteLine("the name of the method - {0}", p.Method.Name));

            Console.WriteLine((action - Hello)("Smithy"));

            Console.WriteLine(action("Martin"));
        }

        private static void GetGenericListCount()
        {
            Func<Book, bool> myFunc = delegate(Book b) { return b.Name.Contains("T"); };
            Console.WriteLine(arrayHelper.returnListCount(books, myFunc));
        }
        private static void GetGenericArrayCount()
        {
            Func<Book, bool> myExpression = delegate(Book c) { return c.Author.Contains("w"); };
            Console.WriteLine(arrayHelper.returnArrayCount(bookies, myExpression));
        }

        private static void GetGenericListCountWithPredicate()
        {
            //Expression<Predicate<Book>> myPredicate = ( b) = b.Name.Contains("T");
            //delegate(Book b) { return b.Name.Contains("T"); };
            // Console.WriteLine(arrayHelper.returnListCountWithPredicate(books, myPredicate));
        }

    }
}

