using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookcase.DAL.DbContext;
using Bookcase.DAL.Repository.IBookcase;

namespace Bookcase.DAL.Repository.Bookcase
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class
    {
        private readonly BookcaseContext _db;

        public GenericRepository(BookcaseContext db)
        {
            _db = db;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _db.Set<TEntity>().AsNoTracking().ToList();
        }

        public TEntity GetObject(int id)
        {
            return _db.Set<TEntity>().Find(id);
        }

        public void Create(TEntity item)
        {
            _db.Set<TEntity>().Add(item);
            _db.SaveChanges();
        }

        public void Update(TEntity item)
        {
            var itemForUpdate = _db.Set<TEntity>().Find(item);

            if(itemForUpdate==null)
                throw new NullReferenceException();

            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var itemForDelete = _db.Set<TEntity>().Find(id);

            if (itemForDelete == null)
                throw new NullReferenceException();

            _db.Set<TEntity>().Remove(itemForDelete);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
