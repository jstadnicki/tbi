namespace ToBeImplemented.Application.Web.Controllers
{
    using System.Web;
    using System.Web.Mvc;

    public class LogoutController : Controller
    {
        [Authorize]
        [HttpGet]
        public ActionResult Index()
        {
            var authentication = this.HttpContext.GetOwinContext().Authentication;
            authentication.SignOut();
            return this.RedirectToAction("List", "Concepts");
        }
    }
}