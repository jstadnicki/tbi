namespace ToBeImplemented.Application.Web.Controllers
{
    using System;
    using System.Web;
    using System.Web.Mvc;

    using ToBeImplemented.Business.Interfaces;

    public class LogoutController : Controller
    {
        private ILoginLogic loginLogic;

        public LogoutController(ILoginLogic loginLogic)
        {
            this.loginLogic = loginLogic;
        }

        [Authorize]
        [HttpGet]
        public ActionResult Index()
        {
            var authentication = this.HttpContext.GetOwinContext().Authentication;
            var result = this.loginLogic.LogOut(authentication);
            if (result.Success)
            {
                return this.RedirectToAction("Index", "Concepts");
            }
            throw new Exception("--- failed to logout ---");
            
        }
    }
}