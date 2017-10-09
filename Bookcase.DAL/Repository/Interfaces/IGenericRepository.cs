using System;
using System.Linq;
using System.Linq.Expressions;
using Bookcase.DAL.DbEntities;

namespace Bookcase.DAL.Repository.Interfaces
{
    public interface IGenericRepository<TEntity> :
        IDisposable
        where TEntity : EntityBase
    {
        TEntity Get(int id);
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);

        TEntity First(Expression<Func<TEntity, bool>> predicate);

        bool Exists(int id);
        bool Exists(Expression<Func<TEntity, bool>> predicate);

        int Count();
        int Count(Expression<Func<TEntity, bool>> predicate);

        TEntity Create(TEntity item);
        TEntity Update(TEntity item);
        void Delete(int id);
        void Save();
    }
}