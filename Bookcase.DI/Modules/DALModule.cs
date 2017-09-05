using Bookcase.DAL.DbContext;
using Bookcase.DAL.UoW.Interfaces;
using Bookcase.DAL.UoW.Realization;
using Ninject.Modules;

namespace Bookcase.DI.Modules
{
    public class DALModule : NinjectModule
    {
        public override void Load()
        {
            Bind<BookcaseContext>().ToSelf();
            Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}
