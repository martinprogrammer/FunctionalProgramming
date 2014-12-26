using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalProgramming
{
    public class BooksContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public BooksContext()
        {
            Database.SetInitializer <BooksContext> (new BooksContextInitializer());
        }

         
     
    
    }
}
