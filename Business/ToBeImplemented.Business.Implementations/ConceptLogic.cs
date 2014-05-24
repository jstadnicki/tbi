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

        public ListConceptViewModel ConceptsOnly()
        {
            var listOfConcepts = this.conceptService.ConceptsOnly();
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

        public ConceptViewModel ConceptOnly(long id)
        {
            var concept = this.conceptService.ConceptOnly(id);
            var result = Mapper.Map<ConceptViewModel>(concept);
            return result;
        }

        public ListConceptViewModel ConceptsWith(string include)
        {
            var propertiesList = include.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            var list = this.conceptService.ConceptsWithProperties(propertiesList);
            var listofConceptsVm = Mapper.Map<List<ConceptViewModel>>(list);
            var result = new ListConceptViewModel { Concepts = listofConceptsVm };
            return result;
        }

        public AddConceptViewModel GetAddConceptViewModel()
        {
            var result = new AddConceptViewModel { AuthorId = 1, };
            return result;
        }

        public long Add(AddConceptViewModel model)
        {
            var concept = Mapper.Map<AddConcept>(model);
            var id = this.conceptService.Add(concept);
            return id;
        }

        public DeleteConceptViewModel GetDeleteViewModel(long id)
        {
            var title = this.conceptService.GetConceptTitle(id);
            var confirmation = "test-concept-delete-confirmation";

            var result = new DeleteConceptViewModel { Title = title, Confirmation = confirmation, Id = id };
            return result;
        }

        public void Delete(long id)
        {
            this.conceptService.Delete(id);
        }

        public UpdateConceptViewModel GetEditConceptViewModel(long id)
        {
            var model = this.conceptService.GetConceptWithTags(id);
            var viewmodel = Mapper.Map<UpdateConceptViewModel>(model);
            return viewmodel;
        }

        public void UpdateConcept(UpdateConceptViewModel model)
        {
            var updateConcept = Mapper.Map<UpdateConcept>(model);
            this.conceptService.UpdateConcept(updateConcept);
        }
    }
}