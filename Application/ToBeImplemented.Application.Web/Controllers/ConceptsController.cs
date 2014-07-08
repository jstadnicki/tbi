using System.Web.Mvc;

namespace ToBeImplemented.Application.Web.Controllers
{
    using System.Web;

    using ToBeImplemented.Business.Interfaces;
    using ToBeImplemented.Business.ViewModel.Concepts;
    using ToBeImplemented.Common.Web;

    public class ConceptsController : Controller, ITbiControllerExtensionMarker
    {
        private readonly IConceptLogic conceptLogic;

        public ConceptsController(IConceptLogic conceptLogic)
        {
            this.conceptLogic = conceptLogic;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var viewModel = this.conceptLogic.List();
            return View("Index", viewModel.Data);
        }

        [HttpGet]
        public ActionResult Details(long id)
        {
            var viewModel = this.conceptLogic.Details(id);
            return this.View("Details", viewModel.Data);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Add()
        {
            var viewModel = this.conceptLogic.GetAddConceptViewModel();
            return this.View("Add", viewModel.Data);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Add(AddConceptViewModel model)
        {
            if (ModelState.IsValid)
            {
                var id = this.conceptLogic.Add(model);
                return this.RedirectToAction("Details", "Concepts", new { id = id });
            }
            else
            {
                return this.View("Add", model);
            }
        }

        [HttpGet]
        [Authorize]
        public ActionResult Delete(long id)
        {
            var viewModel = this.conceptLogic.GetDeleteViewModel(id);
            return this.View("Delete", viewModel.Data);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(DeleteConceptViewModel model)
        {
            this.conceptLogic.Delete(model.Id);
            return this.RedirectToAction("Index", "Concepts");
        }

        [HttpGet]
        [Authorize]
        public ActionResult Edit(long id)
        {
            var viewModel = this.conceptLogic.GetEditConceptViewModel(id);
            return this.View("Edit", viewModel.Data);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UpdateConceptViewModel model)
        {
            if (ModelState.IsValid)
            {
                var currentUser = this.CurrentUser();
                this.conceptLogic.UpdateConcept(model, currentUser);
                return this.RedirectToAction("Details", "Concepts", new { id = model.Id });
            }
            return this.View("Edit", model);
        }

        public HttpContext CurrentContext
        {
            get
            {
                return System.Web.HttpContext.Current;
            }
        }
    }
}