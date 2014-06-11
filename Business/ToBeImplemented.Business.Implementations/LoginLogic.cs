namespace ToBeImplemented.Business.Implementations
{
    using ToBeImplemented.Business.Interfaces;
    using ToBeImplemented.Business.Interfaces.Common;
    using ToBeImplemented.Domain.ViewModel.Users;

    public class LoginLogic : ILoginLogic
    {
        public BussinesResult<LoginViewModel> GetLoginViewModel()
        {
            var data = new LoginViewModel();
            var result = new BussinesResult<LoginViewModel>(data);
            return result;
        }

        public BussinesResult<bool> Login(LoginViewModel loginViewModel)
        {
            throw new System.NotImplementedException();
        }
    }
}