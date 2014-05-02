namespace ToBeImplemented.Business.Implementations
{
    using System.Collections.Generic;

    using AutoMapper;

    using ToBeImplemented.Business.Interfaces;
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
    }
}