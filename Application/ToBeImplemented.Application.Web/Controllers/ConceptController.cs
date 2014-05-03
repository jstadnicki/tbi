using System.Web.Mvc;

namespace ToBeImplemented.Application.Web.Controllers
{
    using ToBeImplemented.Business.Interfaces;
    using ToBeImplemented.Domain.ViewModel;

    public class ConceptController : Controller
    {
        private readonly IConceptLogic conceptLogic;

        public ConceptController(IConceptLogic conceptLogic)
        {
            this.conceptLogic = conceptLogic;
        }

        [HttpGet]
        public ActionResult List()
        {
            var viewModel = this.conceptLogic.List();
            return View("List", viewModel);
        }

        [HttpGet]
        public ActionResult Details(long id)
        {
            var viewModel = this.conceptLogic.Details(id);
            return this.View("Details", viewModel);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var viewModel = this.conceptLogic.GetAddConceptViewModel();
            return this.View("Add", viewModel);
        }

        [HttpPost]
        public ActionResult Add(AddConceptViewModel model)
        {
            if (ModelState.IsValid)
            {
                var id = this.conceptLogic.Add(model);
                return this.RedirectToAction("Details", "Concept", new { id = id });
            }
            else
            {
                return this.View("Add", model);
            }
        }
    }
}