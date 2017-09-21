using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Bookcase.Domain.DomainModels;

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

        Book Create(Book item);
        Book Update(Book item);
        void Delete(int id);
    }
}