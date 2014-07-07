namespace ToBeImplemented.Application.Api.Controllers
{
    using System.Linq;
    using System.Web;
    using System.Web.Http;
    using System.Web.Http.Cors;
    using System.Web.Mvc;

    using Newtonsoft.Json;

    using ToBeImplemented.Business.Interfaces;
    using ToBeImplemented.Common.Web;
    using ToBeImplemented.Domain.ViewModel.Concepts;

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ConceptsController : ApiController, ITbiControllerExtensionMarker
    {
        private readonly IConceptLogic conceptLogic;

        public ConceptsController(IConceptLogic conceptLogic)
        {
            this.conceptLogic = conceptLogic;
        }

        [System.Web.Http.HttpGet]
        public JsonResult Get(string include = "")
        {
            var viewModel = this.conceptLogic.ConceptsWith(include);
            var json = JsonConvert.SerializeObject(viewModel);
            var result = new JsonResult { Data = json, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            return result;
        }

        [System.Web.Http.HttpGet]
        public JsonResult Get(long id)
        {
            var viewModel = this.conceptLogic.ConceptOnly(id);
            var json = JsonConvert.SerializeObject(viewModel);
            var result = new JsonResult { Data = json, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            return result;
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Authorize]
        public JsonResult Post(AddConceptViewModel model)
        {
            string json = null;
            JsonResult result = null;

            if (ModelState.IsValid)
            {
                var newid = this.conceptLogic.Add(model);
                json = JsonConvert.SerializeObject(newid);
                result = new JsonResult { Data = json, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                return result;
            }

            var errors = ModelState.Values.Select(x => x.Errors).ToList();
            json = JsonConvert.SerializeObject(errors);
            result = new JsonResult { Data = json, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            return result;
        }

        [System.Web.Http.Authorize]
        public JsonResult Put(UpdateConceptViewModel model)
        {
            string json = null;
            JsonResult result = null;

            if (ModelState.IsValid)
            {
                var currentUser = this.CurrentUser();
                var operationresult = this.conceptLogic.UpdateConcept(model, currentUser);
                result = new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                return result;
            }

            var errors = ModelState.Values.Select(x => x.Errors).ToList();
            json = JsonConvert.SerializeObject(errors);
            result = new JsonResult { Data = json, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            return result;
        }

        [System.Web.Http.Authorize]
        public JsonResult Delete(long id)
        {
            this.conceptLogic.Delete(id);
            var result = new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet };
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
