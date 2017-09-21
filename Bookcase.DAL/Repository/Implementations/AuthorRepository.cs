using Bookcase.DAL.DbContext;
using Bookcase.DAL.DbEntities;
using Bookcase.DAL.Repository.Interfaces;
using Bookcase.Domain.DomainModels;

namespace Bookcase.DAL.Repository.Implementations
{
    public class AuthorRepository : GenericRepository<AuthorEntity, Author>, IAuthorRepository
    {
        public AuthorRepository(BookcaseContext db) : base(db)
        {
        }
    }
}