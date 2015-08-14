using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using ShepherdsFramework.Web.Controllers;
using StackExchange.Profiling;

namespace ShepherdsFramework.Web
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            //autofac通过对特定的controller注册
            var builder = new ContainerBuilder();
            builder.RegisterType<CustomerController>().InstancePerRequest();
            AreaRegistration.RegisterAllAreas();

            //WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            MiniProfiler.Start();
            HttpContext.Current.Items["ShepherdsFramework.MiniProfiler"] = true;
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            var miniProfilerStarted = HttpContext.Current.Items.Contains("ShepherdsFramework.MiniProfiler") &&
                                      Convert.ToBoolean(HttpContext.Current.Items["ShepherdsFramework.MiniProfiler"]);
            if (miniProfilerStarted)
            {
                MiniProfiler.Stop();
            }
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
        }

        protected void Application_Error(Object sender, EventArgs e)
        {
        }
    }
}