namespace ToBeImplemented.Application.Web.Controllers
{
    using System;
    using System.Linq;
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
            var result = this.usersLogic.GetRegisterViewModel();

            if (result.Success)
            {
                return this.View("Register", result.Data);
            }

            throw new Exception(result.Errors.First());
        }

        [HttpPost]
        public ActionResult Register(RegisterUserViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var result = this.usersLogic.RegisterUser(model);
                if (result.Success)
                {
                    return this.RedirectToAction("Profile", "Users", new { id = result.Data });
                }
                result.Errors.ForEach(x => ModelState.AddModelError(string.Empty, x));
            }

            return this.View("Register", model);
        }

        [HttpGet]
        public ActionResult Profile(long id)
        {
            var model = new UserProfileViewModel() { DisplayName = id.ToString() };
            return this.View("Profile", model);
        }
    }
}