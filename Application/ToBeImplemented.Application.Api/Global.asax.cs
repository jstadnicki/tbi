using System.Web;
using System.Web.Http;

namespace ToBeImplemented.Application.Api
{
    using System.Reflection;

    using Autofac;
    using Autofac.Integration.WebApi;

    using ToBeImplemented.Business.Implementations;
    using ToBeImplemented.Business.Interfaces;
    using ToBeImplemented.Business.Mapper;
    using ToBeImplemented.Infrastructure.EFContext;
    using ToBeImplemented.Infrastructure.Repository;
    using ToBeImplemented.Service.Implementations;
    using ToBeImplemented.Service.Interfaces;

    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            this.Initaaa();
            TbiMapper.Initialize();

        }


        public void Initaaa()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterApiControllers(Assembly.GetCallingAssembly());

            containerBuilder.RegisterType<TbiContext>().As<ITbiContext>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<ConceptRepository>().As<IConceptRepository>();
            containerBuilder.RegisterType<TagRepository>().As<ITagRepository>();
            containerBuilder.RegisterType<ConceptService>().As<IConceptService>();
            containerBuilder.RegisterType<ConceptLogic>().As<IConceptLogic>();

            var container = containerBuilder.Build();

            var resolver = new AutofacWebApiDependencyResolver(container);

            GlobalConfiguration.Configuration.DependencyResolver = resolver;

        }

    }
}
