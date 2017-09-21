using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookcase.DAL.DbEntities;
using Bookcase.Domain.DomainModels;

namespace Bookcase.DAL.Repository.Interfaces
{
    public interface IAuthorBookRepository : IGenericRepository<AuthorBookEntity, AuthorBook>
    {

    }
}
