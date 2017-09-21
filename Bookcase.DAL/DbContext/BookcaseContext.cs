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

            Configuration.ProxyCreationEnabled = false;
            Configuration.AutoDetectChangesEnabled = false;
        }

        public virtual DbSet<BookEntity> Book { get; set; }
        public virtual DbSet<AuthorEntity> Author { get; set; }
        public virtual DbSet<AuthorBookEntity> AuthorBook { get; set; }
    }
}