using System.Web.Http;

namespace ToBeImplemented.Application.Api.Controllers
{
    using System.Linq;
    using System.Web.Http.Cors;
    using System.Web.Mvc;

    using Newtonsoft.Json;

    using ToBeImplemented.Business.Interfaces;
    using ToBeImplemented.Domain.ViewModel;
    using ToBeImplemented.Domain.ViewModel.Concepts;

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ConceptsController : ApiController
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

        public JsonResult Put(UpdateConceptViewModel model)
        {
            string json = null;
            JsonResult result = null;

            if (ModelState.IsValid)
            {
                this.conceptLogic.UpdateConcept(model);
                result = new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                return result;
            }

            var errors = ModelState.Values.Select(x => x.Errors).ToList();
            json = JsonConvert.SerializeObject(errors);
            result = new JsonResult { Data = json, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            return result;
        }

        public JsonResult Delete(long id)
        {
            this.conceptLogic.Delete(id);
            var result = new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            return result;
        }
    }
}
