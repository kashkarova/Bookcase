using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Bookcase.BLL.DTO;

namespace Bookcase.BLL.Services.Interfaces
{
    public interface IBookService
    {
        Book Get(int id);
        List<Book> GetAll();
        List<Book> GetAll(Expression<Func<Book, bool>> predicate);

        Book First(Expression<Func<Book, bool>> predicate);

        bool Exists(int id);
        bool Exists(Expression<Func<Book, bool>> predicate);

        int Count();
        int Count(Expression<Func<Book, bool>> predicate);

        void Create(Book item);
        void Update(Book item);
        void Delete(int id);

        void AddAuthorToBook(int bookId, int authorId);
        void DeleteAuthorFromBook(int bookId, int authorId);
    }
}