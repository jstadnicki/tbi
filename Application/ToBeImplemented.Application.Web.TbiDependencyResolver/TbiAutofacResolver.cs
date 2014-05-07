namespace ToBeImplemented.Application.Web.TbiDependencyResolver
{
    using System.Collections.Generic;
    using System.Reflection;
    using System.Web.Mvc;

    using Autofac;
    using Autofac.Integration.Mvc;

    using ToBeImplemented.Business.Implementations;
    using ToBeImplemented.Business.Interfaces;
    using ToBeImplemented.Domain.Model;
    using ToBeImplemented.Infrastructure.EFContext;
    using ToBeImplemented.Infrastructure.Repository;
    using ToBeImplemented.Service.Implementations;
    using ToBeImplemented.Service.Interfaces;

    public static class TbiAutofacResolver
    {
        public static IContainer Initialize()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterControllers(Assembly.GetCallingAssembly());

            containerBuilder.RegisterType<TbiContext>().As<ITbiContext>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<ConceptRepository>().As<IConceptRepository>();
            containerBuilder.RegisterType<TagRepository>().As<ITagRepository>();
            containerBuilder.RegisterType<ConceptService>().As<IConceptService>();
            containerBuilder.RegisterType<ConceptLogic>().As<IConceptLogic>();

            var container = containerBuilder.Build();

            var autofacDependencyResolver = new AutofacDependencyResolver(container);
            DependencyResolver.SetResolver(autofacDependencyResolver);

            return container;
        }
    }
}
