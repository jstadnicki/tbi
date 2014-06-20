namespace ToBeImplemented.Business.Interfaces
{
    using Microsoft.Owin.Security;

    using ToBeImplemented.Common.Data;
    using ToBeImplemented.Domain.ViewModel.Users;

    public interface ILoginLogic
    {
        OperationResult<LoginViewModel> GetLoginViewModel();
        OperationResult<bool> Login(LoginViewModel loginViewModel, IAuthenticationManager authentication);
    }
}