namespace ToBeImplemented.Application.Api.Controllers
{
    using System.Linq;
    using System.Text;
    using System.Web;
    using System.Web.Http;
    using System.Web.Http.Results;

    using Newtonsoft.Json;

    using ToBeImplemented.Business.Interfaces;
    using ToBeImplemented.Common.Data;
    using ToBeImplemented.Common.Web;
    using ToBeImplemented.Domain.ViewModel.Concepts;

    public class ConceptsController : ApiController, ITbiControllerExtensionMarker
    {
        private readonly IConceptLogic conceptLogic;

        public ConceptsController(IConceptLogic conceptLogic)
        {
            this.conceptLogic = conceptLogic;
        }

        [HttpGet]
        public JsonResult<OperationResult<ListConceptViewModel>> Get(string include = "")
        {
            var viewModel = this.conceptLogic.ConceptsWith(include);

            var result = new JsonResult<OperationResult<ListConceptViewModel>>(
                viewModel,
                new JsonSerializerSettings(),
                Encoding.Default,
                this);

            return result;
        }

        [HttpGet]
        public JsonResult<OperationResult<ConceptViewModel>> Get(long id)
        {
            var viewModel = this.conceptLogic.ConceptOnly(id);
            var result = new JsonResult<OperationResult<ConceptViewModel>>(
                viewModel,
                new JsonSerializerSettings(),
                Encoding.Default,
                this);
            return result;
        }

        [HttpPost]
        [Authorize]
        public JsonResult<OperationResult<long>> Post(AddConceptViewModel model)
        {
            OperationResult<long> operationResult;
            if (ModelState.IsValid)
            {
                operationResult = this.conceptLogic.Add(model);
            }
            else
            {
                var errors =
                    this.ModelState.Values.SelectMany(x => x.Errors).Select(x => x).Select(x => x.ErrorMessage).ToList();
                operationResult = new OperationResult<long>(0, false, errors);

            }

            var result = new JsonResult<OperationResult<long>>(
                 operationResult,
                 new JsonSerializerSettings(),
                 Encoding.Default,
                 this);

            return result;
        }

        [Authorize]
        public JsonResult<OperationResult<bool>> Put(UpdateConceptViewModel model)
        {
            OperationResult<bool> operationResult = null;
            if (ModelState.IsValid)
            {
                var currentUser = this.CurrentUser();
                operationResult = this.conceptLogic.UpdateConcept(model, currentUser);
            }
            else
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
                operationResult = new OperationResult<bool>(false, false, errors);
            }

            var result = new JsonResult<OperationResult<bool>>(
                operationResult,
                new JsonSerializerSettings(),
                Encoding.Default,
                this);

            return result;
        }

        [Authorize]
        public JsonResult<OperationResult<bool>>  Delete(long id)
        {
            var operationResult = this.conceptLogic.Delete(id);
            var result = new JsonResult<OperationResult<bool>>(
                operationResult,
                new JsonSerializerSettings(),
                Encoding.Default,
                this);

            return result;
        }

        public HttpContext CurrentContext
        {
            get
            {
                return HttpContext.Current;
            }
        }
    }
}
