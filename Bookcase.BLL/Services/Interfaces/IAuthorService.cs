using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Bookcase.BLL.DomainModels;

namespace Bookcase.BLL.Services.Interfaces
{
    public interface IAuthorService
    {
        Author Get(int id);
        List<Author> GetAll();
        List<Author> GetAll(Expression<Func<Author, bool>> predicate);

        Author First(Expression<Func<Author, bool>> predicate);

        bool Exists(int id);
        bool Exists(Expression<Func<Author, bool>> predicate);

        int Count();
        int Count(Expression<Func<Author, bool>> predicate);

        Author Create(Author item);
        Author Update(Author item);
        void Delete(int id);
    }
}