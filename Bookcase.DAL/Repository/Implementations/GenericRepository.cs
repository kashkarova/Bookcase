using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Bookcase.DAL.DbContext;
using Bookcase.DAL.DbEntities;
using Bookcase.DAL.Repository.Interfaces;

namespace Bookcase.DAL.Repository.Implementations
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : BaseEntity
    {
        private readonly BookcaseContext _db;

        public GenericRepository(BookcaseContext db)
        {
            _db = db;
        }

        public TEntity Get(int id)
        {
            return _db.Set<TEntity>().Find(id);
        }

        public List<TEntity> GetAll()
        {
            return _db.Set<TEntity>().AsNoTracking().ToList();
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return _db.Set<TEntity>().Where(predicate).AsNoTracking().ToList();
        }

        public TEntity First(Expression<Func<TEntity, bool>> predicate)
        {
            return _db.Set<TEntity>().First(predicate);
        }

        public bool Exists(int id)
        {
            return _db.Set<TEntity>().Any(x => x.Id == id);
        }

        public bool Exists(Expression<Func<TEntity, bool>> predicate)
        {
            return _db.Set<TEntity>().Any(predicate);
        }

        public int Count()
        {
            return _db.Set<TEntity>().Count();
        }

        public int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return _db.Set<TEntity>().Count(predicate);
        }

        public void Create(TEntity item)
        {
            _db.Set<TEntity>().Add(item);
        }

        public void Update(TEntity item)
        {
            var itemForUpdate = _db.Set<TEntity>().Find(item);

            if (itemForUpdate == null)
                throw new NullReferenceException();

            _db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var itemForDelete = _db.Set<TEntity>().Find(id);

            if (itemForDelete == null)
                throw new NullReferenceException();

            _db.Set<TEntity>().Remove(itemForDelete);
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}