namespace ToBeImplemented.Service.Implementations
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using AutoMapper;

    using Microsoft.AspNet.Identity;

    using ToBeImplemented.Business.ViewModel.Users;
    using ToBeImplemented.Domain.Model.Users;
    using ToBeImplemented.Service.Interfaces;
    using ToBeImplemented.Service.Model.Users;

    public class UserService : UserManager<User, long>, IRegisterService, ILoginService, IUserService
    {
        public UserService(IUserPasswordStore<User, long> store)
            : base(store)
        {
        }

        public long RegisterUser(RegisterUser registerUser)
        {
            var user = Mapper.Map<User>(registerUser);
            this.Create(user, registerUser.Password);
            return user.Id;
        }

        public User GetUser(string username, string password)
        {
            var result = this.Find(username, password);
            return result;
        }

        public Task<ClaimsIdentity> GetUserIndentity(LoginViewModel loginViewModel)
        {
            var user = this.FindAsync(loginViewModel.UserName, loginViewModel.Password).Result;
            var identity = this.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            return identity;

        }

        public long GetUserIdFromUserName(string username)
        {
            var task = this.Store.FindByNameAsync(username);
            return task.Result.Id;
        }
    }

}