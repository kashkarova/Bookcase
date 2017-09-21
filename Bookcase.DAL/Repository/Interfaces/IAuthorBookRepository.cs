using Bookcase.DAL.DbEntities;
using Bookcase.Domain.DomainModels;

namespace Bookcase.DAL.Repository.Interfaces
{
    public interface IAuthorBookRepository : IGenericRepository<AuthorBookEntity, AuthorBook>
    {
    }
}