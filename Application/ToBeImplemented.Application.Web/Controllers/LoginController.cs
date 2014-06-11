namespace ToBeImplemented.Application.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using ToBeImplemented.Business.Interfaces;
    using ToBeImplemented.Domain.ViewModel.Users;

    public class LoginController : Controller
    {
        private readonly ILoginLogic loginLogic;

        public LoginController(ILoginLogic loginLogic)
        {
            this.loginLogic = loginLogic;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var result = this.loginLogic.GetLoginViewModel();
            if (result.Success)
            {
                return this.View("Index", result.Data);
            }

            throw new Exception(result.Errors.First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginViewModel loginViewModel)
        {
            var result = this.loginLogic.Login(loginViewModel);
            if (result.Success)
            {
                this.RedirectToAction("Index", "Home");
            }
            return null;
        }
    }
}