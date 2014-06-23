using Microsoft.Owin;

using ToBeImplemented.Application.Api;

[assembly: OwinStartup(typeof(WebApiOwinStartup))]

namespace ToBeImplemented.Application.Api
{
    using System;
    using System.Web.Http;

    using Autofac;

    using DotNetDoodle.Owin;

    using Microsoft.AspNet.Identity;
    using Microsoft.Owin.Security.OAuth;

    using Owin;

    using ToBeImplemented.Application.Web.TbiDependencyResolver;
    using ToBeImplemented.Business.Mapper;
    using ToBeImplemented.Domain.Model.Users;

    public class WebApiOwinStartup
    {
        public void Configuration(IAppBuilder app)
        {
            var container = TbiAutofacResolver.Initialize();
            ConfigureOAuth(app, container);

            var config = new HttpConfiguration();
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            WebApiConfig.Register(config);
            app.UseWebApi(config);

            TbiMapper.Initialize();

            app.UseAutofacContainer(container).UseWebApiWithContainer(config);


        }

        private void ConfigureOAuth(IAppBuilder app, IContainer container)
        {
            var simpleAuthorizationServerProvider =
                new SimpleAuthorizationServerProvider(container.Resolve<UserManager<User, long>>());

            var options = new OAuthAuthorizationServerOptions
                              {
                                  AllowInsecureHttp = true,
                                  TokenEndpointPath = new PathString("/token"),
                                  AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                                  Provider = simpleAuthorizationServerProvider
                              };

            app.UseOAuthAuthorizationServer(options);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}
