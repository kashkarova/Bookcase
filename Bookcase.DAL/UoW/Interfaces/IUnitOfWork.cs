using System;
using Bookcase.DAL.DbEntities;
using Bookcase.DAL.Repository.Interfaces;

namespace Bookcase.DAL.UoW.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<BookEntity> BookRepository { get; }
        IGenericRepository<AuthorEntity> AuthorRepository { get; }

        void Save();
    }
}