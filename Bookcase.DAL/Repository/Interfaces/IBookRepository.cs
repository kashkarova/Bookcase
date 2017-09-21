using Bookcase.DAL.DbEntities;
using Bookcase.Domain.DomainModels;

namespace Bookcase.DAL.Repository.Interfaces
{
    public interface IBookRepository : IGenericRepository<BookEntity, Book>
    {
    }
}