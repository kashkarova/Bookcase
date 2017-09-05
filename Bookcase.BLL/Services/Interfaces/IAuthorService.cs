using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Bookcase.DAL.DbEntities;

namespace Bookcase.BLL.Services.Interfaces
{
    public interface IAuthorService
    {
        AuthorEntity Get(int id);
        List<AuthorEntity> GetAll();
        List<AuthorEntity> GetAll(Expression<Func<AuthorEntity, bool>> predicate);

        AuthorEntity First(Expression<Func<AuthorEntity, bool>> predicate);

        bool Exists(int id);
        bool Exists(Expression<Func<AuthorEntity, bool>> predicate);

        int Count();
        int Count(Expression<Func<AuthorEntity, bool>> predicate);

        void Create(AuthorEntity item);
        void Update(AuthorEntity item);
        void Delete(int id);
    }
}