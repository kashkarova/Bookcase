using Bookcase.DAL.DbContext;
using Bookcase.DAL.DbEntities;
using Bookcase.DAL.Repository.Interfaces;
using Bookcase.Domain.DomainModels;

namespace Bookcase.DAL.Repository.Implementations
{
    public class BookRepository : GenericRepository<BookEntity, Book>, IBookRepository
    {
        public BookRepository(BookcaseContext db) : base(db)
        {
        }
    }
}