namespace ToBeImplemented.Business.Interfaces
{
    using ToBeImplemented.Business.Interfaces.Common;
    using ToBeImplemented.Domain.ViewModel.Users;

    public interface ILoginLogic
    {
        BussinesResult<LoginViewModel> GetLoginViewModel();
        BussinesResult<bool> Login(LoginViewModel loginViewModel);
    }
}