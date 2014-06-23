namespace ToBeImplemented.Application.Api
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.Owin.Security.OAuth;

    using ToBeImplemented.Domain.Model.Users;

    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private readonly UserManager<User, long> userRepository;

        public SimpleAuthorizationServerProvider(UserManager<User, long> userRepository)
        {
            this.userRepository = userRepository;
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            var result = context.Validated();
            return Task.FromResult(result);
        }

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
//            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            var u = this.userRepository.FindAsync(context.UserName, context.Password).Result;
            ClaimsIdentity i = null;

            if (u != null)
            {
                i = new ClaimsIdentity(context.Options.AuthenticationType);
                i.AddClaim(new Claim("sub", context.UserName));
                i.AddClaim(new Claim("role", "user"));
            }
            var result = context.Validated(i);

            return Task.FromResult(result);
        }
    }
}