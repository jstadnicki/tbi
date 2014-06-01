namespace ToBeImplemented.Application.Web.Controllers
{
    using System.Web.Mvc;

    using ToBeImplemented.Business.Interfaces;
    using ToBeImplemented.Domain.ViewModel;
    using ToBeImplemented.Domain.ViewModel.Users;

    public class UserController : Controller
    {
        private readonly IUsersLogic usersLogic;

        public UserController(IUsersLogic usersLogic)
        {
            this.usersLogic = usersLogic;
        }

        [HttpGet]
        public ActionResult Register()
        {
            var model = this.usersLogic.GetRegisterViewModel();
            return this.View("Register", model);
        }

        [HttpPost]
        public ActionResult Register(RegisterUserViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                this.usersLogic.RegisterUser(model);
                return this.RedirectToAction("Profile", "User", new { id = model.DisplayName });
            }
            else
            {
                return this.View("Register", model);
            }

        }

        [HttpGet]
        public ActionResult Profile(string id)
        {
            var model = new UserProfileViewModel() { DisplayName = id };
            return this.View("Profile", model);
        }
    }
}