using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Bookcase.ViewModel;

namespace Bookcase.BLL.Services.Interfaces
{
    public interface IAuthorService
    {
        AuthorViewModel Get(int id);
        List<AuthorViewModel> GetAll();
        List<AuthorViewModel> GetAll(Expression<Func<AuthorViewModel, bool>> predicate);

        AuthorViewModel First(Expression<Func<AuthorViewModel, bool>> predicate);

        bool Exists(int id);
        bool Exists(Expression<Func<AuthorViewModel, bool>> predicate);

        int Count();
        int Count(Expression<Func<AuthorViewModel, bool>> predicate);

        AuthorViewModel Create(AuthorViewModel item);
        AuthorViewModel Update(AuthorViewModel item);
        void Delete(int id);
    }
}