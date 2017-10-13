using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Bookcase.Web.Automapper;

namespace Bookcase.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AutomapperInitializer.Initialize();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}