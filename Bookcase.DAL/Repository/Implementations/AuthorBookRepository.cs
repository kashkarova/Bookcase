using Bookcase.DAL.DbContext;
using Bookcase.DAL.DbEntities;
using Bookcase.DAL.Repository.Interfaces;
using Bookcase.Domain.DomainModels;

namespace Bookcase.DAL.Repository.Implementations
{
    public class AuthorBookRepository : GenericRepository<AuthorBookEntity, AuthorBook>, IAuthorBookRepository
    {
        public AuthorBookRepository(BookcaseContext db) : base(db)
        {
        }
    }
}