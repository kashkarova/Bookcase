using AutoMapper;
using Bookcase.BLL.Automapper;

namespace Bookcase.Web.Automapper
{
    public static class AutomapperInitializer
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<AutomapperEFToViewModel>();
            });

            Mapper.Configuration.AssertConfigurationIsValid();
        }
    }
}