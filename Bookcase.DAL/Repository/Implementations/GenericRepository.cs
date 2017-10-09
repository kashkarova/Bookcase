using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Bookcase.DAL.DbContext;
using Bookcase.DAL.DbEntities;
using Bookcase.DAL.Repository.Interfaces;

namespace Bookcase.DAL.Repository.Implementations
{
    public class GenericRepository<TEntity> :
        IGenericRepository<TEntity>
        where TEntity : EntityBase
    {
        protected readonly BookcaseContext Db;

        public GenericRepository(BookcaseContext db)
        {
            Db = db;
        }

        public virtual TEntity Get(int id)
        {
            return Db.Set<TEntity>().First(x => x.Id == id);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return Db.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return Db.Set<TEntity>().Where(predicate);
        }

        public virtual TEntity First(Expression<Func<TEntity, bool>> predicate)
        {
            return Db.Set<TEntity>().First(predicate);
        }

        public virtual bool Exists(int id)
        {
            return Db.Set<TEntity>().Any(x => x.Id == id);
        }

        public virtual bool Exists(Expression<Func<TEntity, bool>> predicate)
        {
            return Db.Set<TEntity>().Any(predicate);
        }

        public virtual int Count()
        {
            return Db.Set<TEntity>().Count();
        }

        public virtual int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return Db.Set<TEntity>().Count(predicate);
        }

        public virtual TEntity Create(TEntity item)
        {
            var createdEntity = Db.Set<TEntity>().Add(item);

            return createdEntity;
        }

        public virtual TEntity Update(TEntity item)
        {
            Db.Entry(item).State = EntityState.Modified;

            var updatedEntity = Get(item.Id);

            return updatedEntity;
        }

        public virtual void Delete(int id)
        {
            var itemForDelete = Db.Set<TEntity>().Find(id);

            if (itemForDelete == null)
                throw new NullReferenceException();

            Db.Set<TEntity>().Remove(itemForDelete);
        }

        public virtual void Save()
        {
            Db.SaveChanges();
        }

        public virtual void Dispose()
        {
            Db.Dispose();
        }
    }
}