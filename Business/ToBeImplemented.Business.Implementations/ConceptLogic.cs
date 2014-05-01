namespace ToBeImplemented.Business.Implementations
{
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
    }
}