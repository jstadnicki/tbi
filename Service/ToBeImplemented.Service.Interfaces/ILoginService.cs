namespace ToBeImplemented.Service.Interfaces
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using ToBeImplemented.Business.ViewModel.Users;
    using ToBeImplemented.Domain.Model.Users;

    public interface ILoginService
    {
        User GetUser(string username, string password);
        Task<ClaimsIdentity> GetUserIndentity(LoginViewModel loginViewModel);
    }
}