using Bookcase.DAL.DbContext;
using Bookcase.DAL.DbEntities;
using Bookcase.DAL.Repository.Interfaces;

namespace Bookcase.DAL.Repository.Implementations
{
    public class AuthorBookRepository : GenericRepository<AuthorInBook>, IAuthorBookRepository
    {
        public AuthorBookRepository(BookcaseContext db) : base(db)
        {
        }
    }
}