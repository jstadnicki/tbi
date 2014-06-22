namespace ToBeImplemented.Business.Implementations
{
    using System;
    using System.Collections.Generic;

    using AutoMapper;

    using ToBeImplemented.Business.Interfaces;
    using ToBeImplemented.Domain.Model;
    using ToBeImplemented.Domain.ViewModel.Concepts;
    using ToBeImplemented.Service.Interfaces;

    public class ConceptLogic : IConceptLogic
    {
        private readonly IConceptsService conceptsService;

        public ConceptLogic(IConceptsService conceptsService)
        {
            this.conceptsService = conceptsService;
        }

        public ListConceptViewModel List()
        {
            var listOfConcepts = this.conceptsService.GetAllConceptsWithAllCollections();
            var listofConceptsVm = Mapper.Map<List<ConceptViewModel>>(listOfConcepts);

            var result = new ListConceptViewModel { Concepts = listofConceptsVm };
            return result;
        }

        public ListConceptViewModel ConceptsOnly()
        {
            var listOfConcepts = this.conceptsService.ConceptsOnly();
            var listofConceptsVm = Mapper.Map<List<ConceptViewModel>>(listOfConcepts);

            var result = new ListConceptViewModel { Concepts = listofConceptsVm };
            return result;
        }

        public ConceptViewModel Details(long id)
        {
            var concept = this.conceptsService.Details(id);
            var result = Mapper.Map<ConceptViewModel>(concept);
            return result;
        }

        public ConceptViewModel ConceptOnly(long id)
        {
            var concept = this.conceptsService.ConceptOnly(id);
            var result = Mapper.Map<ConceptViewModel>(concept);
            return result;
        }

        public ListConceptViewModel ConceptsWith(string include)
        {
            var propertiesList = include.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            var list = this.conceptsService.ConceptsWithProperties(propertiesList);
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
            var id = this.conceptsService.Add(concept);
            return id;
        }

        public DeleteConceptViewModel GetDeleteViewModel(long id)
        {
            var title = this.conceptsService.GetConceptTitle(id);
            var confirmation = "--- delete concept? ---";

            var result = new DeleteConceptViewModel { Title = title, Confirmation = confirmation, Id = id };
            return result;
        }

        public void Delete(long id)
        {
            this.conceptsService.Delete(id);
        }

        public UpdateConceptViewModel GetEditConceptViewModel(long id)
        {
            var model = this.conceptsService.GetConceptWithTags(id);
            var viewmodel = Mapper.Map<UpdateConceptViewModel>(model);
            return viewmodel;
        }

        public void UpdateConcept(UpdateConceptViewModel model)
        {
            var updateConcept = Mapper.Map<UpdateConcept>(model);
            this.conceptsService.UpdateConcept(updateConcept);
        }
    }
}