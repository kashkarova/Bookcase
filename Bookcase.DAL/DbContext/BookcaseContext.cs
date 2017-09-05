using System.Data.Entity;
using Bookcase.DAL.DbEntities;

namespace Bookcase.DAL.DbContext
{
    public class BookcaseContext : System.Data.Entity.DbContext
    {
        public BookcaseContext()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<BookcaseContext>());
        }

        public DbSet<BookEntity> Book { get; set; }
        public DbSet<AuthorEntity> Author { get; set; }
    }
}