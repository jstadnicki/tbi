namespace ToBeImplemented.Application.Web.TbiDependencyResolver
{
    using System.Reflection;

    using Autofac;
    using Autofac.Integration.Mvc;
    using Autofac.Integration.WebApi;

    using Microsoft.AspNet.Identity;

    using ToBeImplemented.Business.Implementations;
    using ToBeImplemented.Business.Interfaces;
    using ToBeImplemented.Domain.Model.Users;
    using ToBeImplemented.Infrastructure.Adapters;
    using ToBeImplemented.Infrastructure.EFContext;
    using ToBeImplemented.Infrastructure.Interfaces;
    using ToBeImplemented.Infrastructure.Interfaces.Adapters;
    using ToBeImplemented.Infrastructure.Repository;
    using ToBeImplemented.Service.Implementations;
    using ToBeImplemented.Service.Interfaces;

    public static class TbiAutofacResolver
    {
        private static IContainer container;

        public static IContainer Initialize()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterControllers(Assembly.GetCallingAssembly());
            containerBuilder.RegisterApiControllers(Assembly.GetCallingAssembly());

            containerBuilder.RegisterType<TbiContext>().As<ITbiContext>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<ConceptRepository>().As<IConceptRepository>();
            containerBuilder.RegisterType<TagRepository>().As<ITagRepository>();



            containerBuilder.RegisterType<UserService>().As<IRegisterService>();
            containerBuilder.RegisterType<UserService>().As<ILoginService>();
            containerBuilder.RegisterType<UserService>().As<IUserService>();
            
            containerBuilder.RegisterType<ConceptsService>().As<IConceptsService>();
            
            containerBuilder.RegisterType<SimpleSecurityChallengeProvider>().As<ISecurityChallengeProvider>();
            
            containerBuilder.RegisterType<ConceptLogic>().As<IConceptLogic>();
            containerBuilder.RegisterType<RegisterLogic>().As<IRegisterLogic>();
            containerBuilder.RegisterType<LoginLogic>().As<ILoginLogic>();
            
            
            containerBuilder.RegisterType<DateTimeAdapter>().As<IDateTimeAdapter>();
            containerBuilder.RegisterType<GuidAdapter>().As<IGuidAdapter>();






            containerBuilder.RegisterType<UserRepository>().As<IUserStore<User, long>>();
            containerBuilder.RegisterType<UserRepository>().As<IUserPasswordStore<User, long>>();

            TbiAutofacResolver.container = containerBuilder.Build();

            return container;
        }

        public static T Resolve<T>()
        {
            var result = TbiAutofacResolver.container.Resolve<T>();
            return result;
        }
    }
}
