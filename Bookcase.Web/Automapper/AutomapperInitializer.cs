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
                cfg.AddProfile<AutomapperEFToDomainProfile>();
                cfg.AddProfile<AutomapperDomainToViewModelProfile>();

                cfg.ForAllMaps((mapType, mapperExpression) => { mapperExpression.MaxDepth(1); });
            });

            Mapper.Configuration.AssertConfigurationIsValid();
        }
    }
}