﻿using System.Web.Mvc;

namespace ToBeImplemented.Application.Web.Controllers
{
    using ToBeImplemented.Business.Interfaces;

    public class ConceptController : Controller
    {
        private readonly IConceptLogic conceptLogic;

        public ConceptController(IConceptLogic conceptLogic)
        {
            this.conceptLogic = conceptLogic;
        }

        public ActionResult List()
        {
            var viewModel = this.conceptLogic.List();
            return View("List", viewModel);
        }

        public ActionResult Details(long id)
        {
            var viewModel = this.conceptLogic.Details(id);
            return this.View("Details", viewModel);
        }
    }
}