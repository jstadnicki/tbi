namespace ToBeImplemented.Business.Interfaces
{
    using Microsoft.Owin.Security;

    using ToBeImplemented.Business.ViewModel.Users;
    using ToBeImplemented.Common.Data;

    public interface ILoginLogic
    {
        OperationResult<LoginViewModel> GetLoginViewModel();
        OperationResult<bool> Login(LoginViewModel loginViewModel, IAuthenticationManager authentication);
        OperationResult<bool> LogOut(IAuthenticationManager authentication);
    }
}