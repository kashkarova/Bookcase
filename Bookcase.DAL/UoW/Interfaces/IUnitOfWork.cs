using System;
using Bookcase.DAL.Repository.Interfaces;

namespace Bookcase.DAL.UoW.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBookRepository BookRepository { get; }
        IAuthorRepository AuthorRepository { get; }
        IAuthorBookRepository AuthorBookRepository { get; }

        void Save();
    }
}