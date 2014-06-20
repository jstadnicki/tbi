namespace ToBeImplemented.Service.Interfaces
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using ToBeImplemented.Domain.Model.Users;

    public interface ILoginService
    {
        User GetUser(string username, string password);
        Task<ClaimsIdentity> GetUserIndentity(Domain.ViewModel.Users.LoginViewModel loginViewModel);
    }
}