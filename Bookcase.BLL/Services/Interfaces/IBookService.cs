using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Bookcase.DAL.DbEntities;

namespace Bookcase.BLL.Services.Interfaces
{
    public interface IBookService
    {
        BookEntity Get(int id);
        List<BookEntity> GetAll();
        List<BookEntity> GetAll(Expression<Func<BookEntity, bool>> predicate);

        BookEntity First(Expression<Func<BookEntity, bool>> predicate);

        bool Exists(int id);
        bool Exists(Expression<Func<BookEntity, bool>> predicate);

        int Count();
        int Count(Expression<Func<BookEntity, bool>> predicate);

        void Create(BookEntity item);
        void Update(BookEntity item);
        void Delete(int id);

        void AddAuthorToBook(int bookId, int authorId);
        void DeleteAuthorFromBook(int bookId, int authorId);
    }
}