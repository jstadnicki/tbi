using Microsoft.Owin;

[assembly: OwinStartup(typeof(ToBeImplemented.Application.Web.Startup))]
namespace ToBeImplemented.Application.Web
{
    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin.Security.Cookies;

    using Owin;

    using ToBeImplemented.Domain.Model.Users;
    using ToBeImplemented.Service.Implementations;
    using ToBeImplemented.Service.Interfaces;

    public class Startup
    {
        private IUserService userService;

        public void Configuration(IAppBuilder app)
        {
            this.userService = TbiDependencyResolver.TbiAutofacResolver.Resolve<IUserService>();
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<UserService, User, long>(
                    TimeSpan.FromMinutes(30), RegenerateIdentityCallback, GetUserIdCallback)

                }
            });
        }

        private long GetUserIdCallback(ClaimsIdentity claimsIdentity)
        {
            var id = this.userService.GetUserIdFromUserName(claimsIdentity.Name);
            return id;
        }

        private Task<ClaimsIdentity> RegenerateIdentityCallback(UserService userService, User user)
        {
            var identity = userService.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            return identity;
        }
    }


    public class ApplicationUserManager : UserManager<User, long>
    {
        public ApplicationUserManager(IUserStore<User, long> store)
            : base(store)
        {
        }
    }
}