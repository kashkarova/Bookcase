using System.Data.Entity;
using System.Linq;
using Bookcase.DAL.DbEntities;

namespace Bookcase.DAL.DbContext
{
    public class BookcaseContext : System.Data.Entity.DbContext
    {
        public DbSet<BookEntity> Book { get; set; }
        public DbSet<AuthorEntity> Author { get; set; }

        public BookcaseContext()
        {
            Database.SetInitializer<BookcaseContext>(new CreateDatabaseIfNotExists<BookcaseContext>());
            Book.Where(x => x.Title == "");
        }
    }
}