using Bookcase.DAL.DbEntities;
using Bookcase.Domain.DomainModels;

namespace Bookcase.DAL.Repository.Interfaces
{
    public interface IAuthorRepository : IGenericRepository<AuthorEntity, Author>
    {
    }
}