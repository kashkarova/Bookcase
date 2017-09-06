using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Bookcase.BLL.DTO;
using Bookcase.DAL.DbEntities;

namespace Bookcase.BLL.Services.Interfaces
{
    public interface IAuthorService
    {
        Author Get(int id);
        List<Author> GetAll();
        List<Author> GetAll(Expression<Func<AuthorEntity, bool>> predicate);

        Author First(Expression<Func<AuthorEntity, bool>> predicate);

        bool Exists(int id);
        bool Exists(Expression<Func<AuthorEntity, bool>> predicate);

        int Count();
        int Count(Expression<Func<AuthorEntity, bool>> predicate);

        void Create(AuthorEntity item);
        void Update(AuthorEntity item);
        void Delete(int id);
    }
}