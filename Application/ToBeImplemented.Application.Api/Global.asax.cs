using System.Web;
using System.Web.Http;

namespace ToBeImplemented.Application.Api
{
    using Autofac.Integration.WebApi;

    using ToBeImplemented.Application.Web.TbiDependencyResolver;
    using ToBeImplemented.Business.Mapper;

    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            var container = TbiAutofacResolver.Initialize();
            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
            TbiMapper.Initialize();
        }
    }
}
