namespace TbiDependencyResolver
{
    using System.Reflection;

    using Autofac;
    using Autofac.Integration.Mvc;

    using ToBeImplemented.Infrastructure.EFContext;
    using ToBeImplemented.Infrastructure.Repository;
    using ToBeImplemented.Service.Implementations;
    using ToBeImplemented.Service.Interfaces;
    using System.Web.Mvc;

    public static class TbiAutofacResolver
    {
        public static IContainer Initialize()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterControllers(Assembly.GetExecutingAssembly());

            containerBuilder.RegisterType<TbiContext>().As<ITbiContext>();
            containerBuilder.RegisterType<ConceptRepository>().As<IConceptRepository>();
            containerBuilder.RegisterType<ConceptService>().As<IConceptService>();

            var container = containerBuilder.Build();

            var autofacDependencyResolver = new AutofacDependencyResolver(container);
            DependencyResolver.SetResolver(autofacDependencyResolver);

            return container;
        }
    }
}
