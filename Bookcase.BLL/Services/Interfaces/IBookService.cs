using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Bookcase.BLL.DTO;
using Bookcase.DAL.DbEntities;

namespace Bookcase.BLL.Services.Interfaces
{
    public interface IBookService
    {
        BookDTO Get(int id);
        List<BookDTO> GetAll();
        List<BookDTO> GetAll(Expression<Func<BookEntity, bool>> predicate);

        BookDTO First(Expression<Func<BookEntity, bool>> predicate);

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