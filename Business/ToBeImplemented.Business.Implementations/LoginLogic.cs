namespace ToBeImplemented.Business.Implementations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.Owin.Security;

    using ToBeImplemented.Business.Interfaces;
    using ToBeImplemented.Common.Data;
    using ToBeImplemented.Domain.ViewModel.Users;
    using ToBeImplemented.Service.Interfaces;

    public class LoginLogic : ILoginLogic
    {
        private readonly ILoginService loginService;

        public LoginLogic(ILoginService loginService)
        {
            this.loginService = loginService;
        }

        public OperationResult<LoginViewModel> GetLoginViewModel()
        {
            var data = new LoginViewModel();
            var result = new OperationResult<LoginViewModel>(data);
            return result;
        }

        public OperationResult<bool> Login(LoginViewModel loginViewModel, IAuthenticationManager authentication)
        {
            var identity = this.loginService.GetUserIndentity(loginViewModel);

            authentication.SignOut(DefaultAuthenticationTypes.ExternalCookie);

            var r = identity.Result;
            authentication.SignIn(new AuthenticationProperties() { IsPersistent = false }, r);

            return new OperationResult<bool>(true);
        }
    }
}