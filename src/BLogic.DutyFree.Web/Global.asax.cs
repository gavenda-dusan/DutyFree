using DutyFree.Web.Configuration;
using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace DutyFree.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            SetUpDependencyConfig();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected virtual void SetUpDependencyConfig()
        {
            var container = new DependencyConfig().BuildContainer();
        }

        protected void Application_AcquireRequestState()
        {
            SetCultureForCurrentThread();
        }

        protected void SetCultureForCurrentThread()
        {
            var culture = new CultureInfo("cs-CZ");
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
        }
    }
}
