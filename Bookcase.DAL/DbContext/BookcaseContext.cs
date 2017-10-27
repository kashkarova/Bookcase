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

            //Configuration.ProxyCreationEnabled = false;
            //Configuration.AutoDetectChangesEnabled = false;
        }

        public DbSet<Book> Book { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<AuthorInBook> AuthorBook { get; set; }
    }
}