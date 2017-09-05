using Bookcase.DAL.DbContext;
using Bookcase.DAL.DbEntities;
using Bookcase.DAL.Repository.Implementations;
using Bookcase.DAL.Repository.Interfaces;
using Bookcase.DAL.UoW.Interfaces;

namespace Bookcase.DAL.UoW.Realization
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookcaseContext _db;

        public IGenericRepository<BookEntity> BookRepository { get; }
        public IGenericRepository<AuthorEntity> AuthorRepository { get; }

        public UnitOfWork(BookcaseContext db)
        {
            _db = db;

            BookRepository = new GenericRepository<BookEntity>(_db);
            AuthorRepository = new GenericRepository<AuthorEntity>(_db);
        }

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