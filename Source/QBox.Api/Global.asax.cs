using System.Data.Entity;
using System.Web.Http;
using System.Web.Mvc;
using QBox.Api.Database;
using QBox.Api.Migrations;

namespace QBox.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            GlobalConfiguration.Configuration.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;

            Microsoft.ApplicationInsights.Extensibility.TelemetryConfiguration.Active.InstrumentationKey =
    Properties.Settings.Default.InstrumentationKey;

        }
    }
}
