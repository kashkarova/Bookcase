using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookcase.DAL.Repository.IBookcase
{
    public interface IGenericRepository<TEntity> : IDisposable
        where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetObject(int id);
        void Create(TEntity item);
        void Update(TEntity item);
        void Delete(int id);
        void Save();
    }
}
