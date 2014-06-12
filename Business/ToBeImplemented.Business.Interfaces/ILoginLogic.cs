namespace ToBeImplemented.Business.Interfaces
{
    using ToBeImplemented.Common.Data;
    using ToBeImplemented.Domain.ViewModel.Users;

    public interface ILoginLogic
    {
        OperationResult<LoginViewModel> GetLoginViewModel();
        OperationResult<bool> Login(LoginViewModel loginViewModel);
    }
}