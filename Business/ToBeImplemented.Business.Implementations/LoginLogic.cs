﻿namespace ToBeImplemented.Business.Implementations
{
    using Microsoft.Owin.Security;

    using ToBeImplemented.Business.Interfaces;
    using ToBeImplemented.Business.ViewModel.Users;
    using ToBeImplemented.Common.Data;
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
            var userIdentity = identity.Result;
            authentication.SignIn(new AuthenticationProperties { IsPersistent = loginViewModel.RememberMe }, userIdentity);
            return new OperationResult<bool>(true);
        }

        public OperationResult<bool> LogOut(IAuthenticationManager authentication)
        {
            authentication.SignOut();
            var result = new OperationResult<bool>(true);
            return result;
        }
    }
}