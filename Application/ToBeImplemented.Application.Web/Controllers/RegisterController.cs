namespace ToBeImplemented.Application.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using ToBeImplemented.Business.Interfaces;
    using ToBeImplemented.Domain.ViewModel.Users;

    public class RegisterController : Controller
    {
        private readonly IRegisterLogic registerLogic;

        public RegisterController(IRegisterLogic registerLogic)
        {
            this.registerLogic = registerLogic;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var result = this.registerLogic.GetRegisterViewModel();

            if (result.Success)
            {
                return this.View("Index", result.Data);
            }

            throw new Exception(result.Errors.First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(RegisterUserViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var result = this.registerLogic.RegisterUser(model);
                if (result.Success)
                {
                    return this.RedirectToAction("Profile", "Register", new { id = result.Data });
                }
                result.Errors.ForEach(x => ModelState.AddModelError(string.Empty, x));
            }

            return this.View("Index", model);
        }

        [HttpGet]
        public ActionResult Profile(long id)
        {
            var model = new UserProfileViewModel() { DisplayName = id.ToString() };
            return this.View("Profile", model);
        }

    }
}