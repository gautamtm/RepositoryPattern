using Autofac;
//using Microsoft.Owin.Builder;
//using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac.Integration.Mvc;
namespace TestDemo
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var container = Service.Configuration.AutofacContainerBuilder.BuildContainer();
            container.RegisterControllers(typeof(MvcApplication).Assembly);
            var build = container.Build();

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(build));

        }
    }
}
