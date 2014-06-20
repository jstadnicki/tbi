namespace ToBeImplemented.Service.Implementations
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using AutoMapper;

    using Microsoft.AspNet.Identity;

    using ToBeImplemented.Domain.Model.Users;
    using ToBeImplemented.Domain.ViewModel.Users;
    using ToBeImplemented.Service.Interfaces;

    public class UserService : UserManager<User, long>, IRegisterService, ILoginService, IUserService
    {
        public UserService(IUserPasswordStore<User, long> store)
            : base(store)
        {
        }

        public long RegisterUser(RegisterUser registerUser)
        {
            var user = Mapper.Map<User>(registerUser);
            var result = this.Create(user, registerUser.Password);
            return user.Id;
        }

        public User GetUser(string username, string password)
        {
            var result = this.Find(username, password);
            return result;
        }

        public Task<ClaimsIdentity> GetUserIndentity(LoginViewModel loginViewModel)
        {
            var r = this.FindAsync(loginViewModel.UserName, loginViewModel.Password)
                 .ContinueWith(t => this.CreateIdentityAsync(t.Result, DefaultAuthenticationTypes.ApplicationCookie).Result);
            return r;

        }

        public long GetUserIdFromUserName(string username)
        {
            var t = this.Store.FindByNameAsync(username);
            return t.Result.Id;
        }
    }

}