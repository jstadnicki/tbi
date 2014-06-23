namespace ToBeImplemented.Application.Api.Controllers
{
    using System.Linq;
    using System.Text;
    using System.Web.Http;
    using System.Web.Http.Results;

    using Newtonsoft.Json;

    using ToBeImplemented.Business.Interfaces;
    using ToBeImplemented.Domain.ViewModel.Users;

    public class RegisterController : ApiController
    {
        private readonly IRegisterLogic registerLogic;

        public RegisterController(IRegisterLogic registerLogic)
        {
            this.registerLogic = registerLogic;
        }

        public JsonResult<string> Post(RegisterUserViewModel model)
        {
            JsonResult<string> result;
            var js = new JsonSerializerSettings();
            if (ModelState.IsValid)
            {
                var registerResult = this.registerLogic.RegisterUser(model);
                if (registerResult.Success)
                {
                    result = new JsonResult<string>(registerResult.Data.ToString(), js, Encoding.Default, this);
                }
                else
                {
                    var flattenErrors = string.Join(";", registerResult.Errors);
                    result = new JsonResult<string>(flattenErrors, js, Encoding.Default, this);
                }
            }
            else
            {
                var flattenErrors = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x=>x.ErrorMessage));
                result = new JsonResult<string>(flattenErrors, js, Encoding.Default, this);
            }
            return result;
        }

    }
}