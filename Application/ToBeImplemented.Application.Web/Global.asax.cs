﻿using System.Web.Mvc;
using System.Web.Routing;

namespace ToBeImplemented.Application.Web
{
    using ToBeImplemented.Application.Web.TbiDependencyResolver;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            TbiAutofacResolver.Initialize();
        }
    }
}