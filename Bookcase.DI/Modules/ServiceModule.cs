using Bookcase.BLL.Services.Interfaces;
using Bookcase.BLL.Services.Realization;
using Ninject.Modules;

namespace Bookcase.DI.Modules
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IAuthorService>().To<AuthorService>();
            Bind<IBookService>().To<BookService>();
        }
    }
}