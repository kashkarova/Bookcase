using Bookcase.DAL.DbContext;
using Bookcase.DAL.Repository.Implementations;
using Bookcase.DAL.Repository.Interfaces;
using Bookcase.DAL.UoW.Interfaces;

namespace Bookcase.DAL.UoW.Realization
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookcaseContext _db;

        public UnitOfWork(BookcaseContext db)
        {
            _db = db;

            BookRepository = new BookRepository(_db);
            AuthorRepository = new AuthorRepository(_db);
            AuthorBookRepository=new AuthorBookRepository(_db);
        }

        public IBookRepository BookRepository { get; }
        public IAuthorRepository AuthorRepository { get; }
        public IAuthorBookRepository AuthorBookRepository { get; }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}