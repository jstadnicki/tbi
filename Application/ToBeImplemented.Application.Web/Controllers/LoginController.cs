namespace ToBeImplemented.Application.Web.Controllers
{
    using System.Web;
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
            var r = this.loginLogic.GetLoginViewModel();
            return this.View("Index", r.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginViewModel loginViewModel)
        {
            var authentication = this.HttpContext.GetOwinContext().Authentication;
            var result = this.loginLogic.Login(loginViewModel, authentication);
            if (result.Success)
            {
                return this.RedirectToAction("List", "Concepts");
            }
            return null;
        }
    }
    
}