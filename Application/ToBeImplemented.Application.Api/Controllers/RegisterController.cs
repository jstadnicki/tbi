namespace ToBeImplemented.Application.Api.Controllers
{
    using System.Linq;
    using System.Text;
    using System.Web.Http;
    using System.Web.Http.Results;

    using Newtonsoft.Json;

    using ToBeImplemented.Business.Interfaces;
    using ToBeImplemented.Business.ViewModel.Users;
    using ToBeImplemented.Common.Data;

    public class RegisterController : ApiController
    {
        private readonly IRegisterLogic registerLogic;

        public RegisterController(IRegisterLogic registerLogic)
        {
            this.registerLogic = registerLogic;
        }

        public JsonResult<OperationResult<long>> Post(RegisterUserViewModel model)
        {
            JsonResult<OperationResult<long>> result;
            var js = new JsonSerializerSettings();
            if (ModelState.IsValid)
            {
                var registerResult = this.registerLogic.RegisterUser(model);
                result = new JsonResult<OperationResult<long>>(registerResult, js, Encoding.Default, this);
            }
            else
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage);
                var faultyResult = new OperationResult<long>(-1, false, errors.ToList());
                result = new JsonResult<OperationResult<long>>(faultyResult, js, Encoding.Default, this);
            }
            return result;
        }

        public JsonResult<OperationResult<RegisterUserViewModel>> Get()
        {
            var operationResult = this.registerLogic.GetRegisterViewModel();
            var js = new JsonSerializerSettings();
            var result = new JsonResult<OperationResult<RegisterUserViewModel>>(
                operationResult,
                js,
                Encoding.Default,
                this);

            return result;
        }

    }
}
