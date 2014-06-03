namespace ToBeImplemented.Application.Web.Controllers
{
    using System.Web.Mvc;

    using ToBeImplemented.Business.Interfaces;
    using ToBeImplemented.Domain.ViewModel.Users;

    public class UsersController : Controller
    {
        private readonly IUsersLogic usersLogic;

        public UsersController(IUsersLogic usersLogic)
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
                var id = this.usersLogic.RegisterUser(model);
                return this.RedirectToAction("Profile", "Users", new { id = id });
            }
            else
            {
                return this.View("Register", model);
            }
        }

        [HttpGet]
        public ActionResult Profile(long id)
        {
            var model = new UserProfileViewModel() { DisplayName = id.ToString() };
            return this.View("Profile", model);
        }
    }
}