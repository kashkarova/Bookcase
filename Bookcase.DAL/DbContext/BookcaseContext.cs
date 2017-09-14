using System.Data.Entity;
using Bookcase.DAL.DbEntities;
using Bookcase.DAL.Migrations;

namespace Bookcase.DAL.DbContext
{
    public class BookcaseContext : System.Data.Entity.DbContext
    {
        public BookcaseContext() : base("BookcaseDb")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookcaseContext, Configuration>());
        }

        public DbSet<BookEntity> Book { get; set; }
        public DbSet<AuthorEntity> Author { get; set; }

    }
}