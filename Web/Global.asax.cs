using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Optimization;

namespace Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
	        log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo(Server.MapPath("~/App_Data/log4net.config")));
			InjectionConfig.Init();
            MapConfig.Init();
        }
    }
}
