using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Bookcase.DAL.DbContext;
using Bookcase.DAL.DbEntities;
using Bookcase.DAL.Repository.Interfaces;
using Bookcase.Domain.DomainModels;

namespace Bookcase.DAL.Repository.Implementations
{
    public class GenericRepository<TEntity, TDomain> :
        IGenericRepository<TEntity, TDomain>
        where TEntity : EntityBase
        where TDomain : DomainBase
    {
        protected readonly BookcaseContext Db;

        public GenericRepository(BookcaseContext db)
        {
            Db = db;
        }

        public virtual TDomain Get(int id)
        {
            return Db.Set<TEntity>().ProjectTo<TDomain>().First(x => x.Id == id);
        }

        public virtual IQueryable<TDomain> GetAll()
        {
            return Db.Set<TEntity>().ProjectTo<TDomain>();
        }

        public virtual IQueryable<TDomain> GetAll(Expression<Func<TDomain, bool>> predicate)
        {
            return Db.Set<TEntity>().ProjectTo<TDomain>().Where(predicate);
        }

        public virtual TDomain First(Expression<Func<TDomain, bool>> predicate)
        {
            return Db.Set<TEntity>().ProjectTo<TDomain>().First(predicate);
        }

        public virtual bool Exists(int id)
        {
            return Db.Set<TEntity>().Any(x => x.Id == id);
        }

        public virtual bool Exists(Expression<Func<TDomain, bool>> predicate)
        {
            return Db.Set<TEntity>().ProjectTo<TDomain>().Any(predicate);
        }

        public virtual int Count()
        {
            return Db.Set<TEntity>().Count();
        }

        public virtual int Count(Expression<Func<TDomain, bool>> predicate)
        {
            return Db.Set<TEntity>().ProjectTo<TDomain>().Count(predicate);
        }

        public virtual TDomain Create(TDomain item)
        {
            var mappedEntity = Mapper.Map<TDomain, TEntity>(item);
            var unmappedEntity = Db.Set<TEntity>().Add(mappedEntity);
            var mappedDomain = Mapper.Map<TEntity, TDomain>(unmappedEntity);

            return mappedDomain;
        }

        public virtual TDomain Update(TDomain item)
        {
            var mappedEntity = Mapper.Map<TDomain, TEntity>(item);
            Db.Entry(mappedEntity).State = EntityState.Modified;

            var unmappedDomain = Mapper.Map<TEntity, TDomain>(mappedEntity);

            return unmappedDomain;
        }

        public virtual void Delete(int id)
        {
            var itemForDelete = Db.Set<TEntity>().Find(id);

            if (itemForDelete == null)
                throw new NullReferenceException();

            Db.Set<TEntity>().Remove(itemForDelete);
        }

        public virtual void Dispose()
        {
            Db.Dispose();
        }
    }
}