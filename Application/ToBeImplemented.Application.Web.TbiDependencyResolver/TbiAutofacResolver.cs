namespace ToBeImplemented.Application.Web.TbiDependencyResolver
{
    using System;
    using System.Reflection;
    using System.Web.Mvc;

    using Autofac;
    using Autofac.Integration.Mvc;
    using Autofac.Integration.WebApi;

    using ToBeImplemented.Business.Implementations;
    using ToBeImplemented.Business.Interfaces;
    using ToBeImplemented.Infrastructure.Adapters;
    using ToBeImplemented.Infrastructure.EFContext;
    using ToBeImplemented.Infrastructure.Interfaces;
    using ToBeImplemented.Infrastructure.Interfaces.Adapters;
    using ToBeImplemented.Infrastructure.Repository;
    using ToBeImplemented.Service.Implementations;
    using ToBeImplemented.Service.Interfaces;

    public static class TbiAutofacResolver
    {
        public static IContainer Initialize()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterControllers(Assembly.GetCallingAssembly());
            containerBuilder.RegisterApiControllers(Assembly.GetCallingAssembly());

            containerBuilder.RegisterType<TbiContext>().As<ITbiContext>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<ConceptRepository>().As<IConceptRepository>();
            containerBuilder.RegisterType<TagRepository>().As<ITagRepository>();
            containerBuilder.RegisterType<UserRepository>().As<IUserRepository>();
            
            containerBuilder.RegisterType<ConceptService>().As<IConceptService>();
            containerBuilder.RegisterType<RegisterService>().As<IRegisterService>();
            containerBuilder.RegisterType<Md5UserPasswordHasher>().As<IUserPasswordHasher>();
            
            containerBuilder.RegisterType<SimpleSecurityChallengeProvider>().As<ISecurityChallengeProvider>();
            
            containerBuilder.RegisterType<ConceptLogic>().As<IConceptLogic>();
            containerBuilder.RegisterType<RegisterLogic>().As<IRegisterLogic>();
            
            
            containerBuilder.RegisterType<DateTimeAdapter>().As<IDateTimeAdapter>();
            containerBuilder.RegisterType<GuidAdapter>().As<IGuidAdapter>();

            var container = containerBuilder.Build();

            

            return container;
        }
    }
}
