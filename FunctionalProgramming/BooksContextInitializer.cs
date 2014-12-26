using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace FunctionalProgramming
{
    public class BooksContextInitializer : DropCreateDatabaseIfModelChanges<BooksContext>
    {
        protected override void Seed(BooksContext context)
        {
            context.Books.Add(new Book()
            {
                Name = "Taras Buljba",
                Author = "Petar Potemkin"
            });
            context.Books.Add(new Book()
            {
                Name = "Od domda do pomda",
                Author = "Siljko Siljkovic"
            });
            context.Books.Add(new Book()
            {
                Name = "Oliver Twist",
                Author = "Sam Peckinpoe"
            });
            context.Books.Add(new Book()
            {
                Name = "Garden of Eden",
                Author = "Sly Stallone"
            });

            context.SaveChanges();

            base.Seed(context);
        }





    }
}
