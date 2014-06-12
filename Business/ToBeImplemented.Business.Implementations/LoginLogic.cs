namespace ToBeImplemented.Business.Implementations
{
    using ToBeImplemented.Business.Interfaces;
    using ToBeImplemented.Common.Data;
    using ToBeImplemented.Domain.ViewModel.Users;
    using ToBeImplemented.Service.Interfaces;

    public class LoginLogic : ILoginLogic
    {
        private readonly ILoginService loginService;

        public LoginLogic(ILoginService loginService, IUserPasswordHasher userPasswordHasher)
        {
            this.loginService = loginService;
        }

        public OperationResult<LoginViewModel> GetLoginViewModel()
        {
            var data = new LoginViewModel();
            var result = new OperationResult<LoginViewModel>(data);
            return result;
        }

        public OperationResult<bool> Login(LoginViewModel loginViewModel)
        {
            throw new System.NotImplementedException();
        }
    }
}