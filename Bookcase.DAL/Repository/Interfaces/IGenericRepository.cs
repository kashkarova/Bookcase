using System;
using System.Linq;
using System.Linq.Expressions;
using Bookcase.DAL.DbEntities;
using Bookcase.Domain.DomainModels;

namespace Bookcase.DAL.Repository.Interfaces
{
    public interface IGenericRepository<TEntity, TDomain> :
        IDisposable
        where TEntity : EntityBase
        where TDomain : DomainBase
    {
        TDomain Get(int id);
        IQueryable<TDomain> GetAll();
        IQueryable<TDomain> GetAll(Expression<Func<TDomain, bool>> predicate);

        TDomain First(Expression<Func<TDomain, bool>> predicate);

        bool Exists(int id);
        bool Exists(Expression<Func<TDomain, bool>> predicate);

        int Count();
        int Count(Expression<Func<TDomain, bool>> predicate);

        TDomain Create(TDomain item);
        TDomain Update(TDomain item);
        void Delete(int id);
    }
}