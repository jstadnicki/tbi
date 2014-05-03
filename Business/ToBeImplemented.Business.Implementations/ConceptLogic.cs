namespace ToBeImplemented.Business.Implementations
{
    using System;
    using System.Collections.Generic;

    using AutoMapper;

    using ToBeImplemented.Business.Interfaces;
    using ToBeImplemented.Domain.Model;
    using ToBeImplemented.Domain.ViewModel;
    using ToBeImplemented.Service.Interfaces;

    public class ConceptLogic : IConceptLogic
    {
        private readonly IConceptService conceptService;

        public ConceptLogic(IConceptService conceptService)
        {
            this.conceptService = conceptService;
        }

        public ListConceptViewModel List()
        {
            var listOfConcepts = this.conceptService.GetAllConceptsWithAllCollections();
            var listofConceptsVm = Mapper.Map<List<ConceptViewModel>>(listOfConcepts);

            var result = new ListConceptViewModel { Concepts = listofConceptsVm };
            return result;
        }

        public ConceptViewModel Details(long id)
        {
            var concept = this.conceptService.Details(id);
            var result = Mapper.Map<ConceptViewModel>(concept);
            return result;
        }

        public AddConceptViewModel GetAddConceptViewModel()
        {
            var result = new AddConceptViewModel { AuthorId = 1, };
            return result;
        }

        public long Add(AddConceptViewModel model)
        {
            var concept = Mapper.Map<Concept>(model);
            var  now = DateTime.Now;
            concept.Created = now;
            concept.LastUpdate = now;
            var id = this.conceptService.Add(concept);
            return id;
        }
    }
}