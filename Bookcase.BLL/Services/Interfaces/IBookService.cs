using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Bookcase.ViewModel;

namespace Bookcase.BLL.Services.Interfaces
{
    public interface IBookService
    {
        BookViewModel Get(int id);
        List<BookViewModel> GetAll();
        List<BookViewModel> GetAll(Expression<Func<BookViewModel, bool>> predicate);

        BookViewModel First(Expression<Func<BookViewModel, bool>> predicate);

        bool Exists(int id);
        bool Exists(Expression<Func<BookViewModel, bool>> predicate);

        int Count();
        int Count(Expression<Func<BookViewModel, bool>> predicate);

        BookViewModel Create(BookViewModel item);
        BookViewModel Update(BookViewModel item);
        void Delete(int id);

        void AddAuthorToBook(int bookId, int authorId);
        void DeleteAuthorFromBook(int bookId, int authorId);

        List<AuthorViewModel> GetAuthorsByBook(int bookId);
    }
}