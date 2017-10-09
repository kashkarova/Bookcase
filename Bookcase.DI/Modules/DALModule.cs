using Bookcase.DAL.DbContext;
using Bookcase.DAL.Repository.Implementations;
using Bookcase.DAL.Repository.Interfaces;
using Ninject.Modules;

namespace Bookcase.DI.Modules
{
    public class DALModule : NinjectModule
    {
        public override void Load()
        {
            Bind<BookcaseContext>().ToSelf();
            Bind<IBookRepository>().To<BookRepository>();
            Bind<IAuthorRepository>().To<AuthorRepository>();
            Bind<IAuthorBookRepository>().To<AuthorBookRepository>();
        }
    }
}