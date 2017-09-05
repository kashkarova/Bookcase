using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Bookcase.DAL.DbEntities;

namespace Bookcase.DAL.Repository.Interfaces
{
    public interface IGenericRepository<TEntity> : IDisposable
        where TEntity : BaseEntity
    {
        TEntity Get(int id);
        List<TEntity> GetAll();
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);

        TEntity First(Expression<Func<TEntity, bool>> predicate);

        bool Exists(int id);
        bool Exists(Expression<Func<TEntity, bool>> predicate);

        int Count();
        int Count(Expression<Func<TEntity, bool>> predicate);
        
        void Create(TEntity item);
        void Update(TEntity item);
        void Delete(int id);
    }
}