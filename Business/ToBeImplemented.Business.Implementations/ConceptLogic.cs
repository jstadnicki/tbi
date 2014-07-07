namespace ToBeImplemented.Business.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;

    using AutoMapper;

    using ToBeImplemented.Business.Interfaces;
    using ToBeImplemented.Common.Data;
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

        public OperationResult<ListConceptViewModel> List()
        {
            var listOfConcepts = this.conceptsService.GetAllConceptsWithAllCollections();
            var listofConceptsVm = Mapper.Map<List<ConceptViewModel>>(listOfConcepts);

            var result = new ListConceptViewModel { Concepts = listofConceptsVm };
            return new OperationResult<ListConceptViewModel>(result);
        }

        public OperationResult<ListConceptViewModel> ConceptsOnly()
        {
            var listOfConcepts = this.conceptsService.ConceptsOnly();
            var listofConceptsVm = Mapper.Map<List<ConceptViewModel>>(listOfConcepts);

            var result = new ListConceptViewModel { Concepts = listofConceptsVm };
            return new OperationResult<ListConceptViewModel>(result);
        }

        public OperationResult<ConceptViewModel> Details(long id)
        {
            var concept = this.conceptsService.Details(id);
            var result = Mapper.Map<ConceptViewModel>(concept);
            return new OperationResult<ConceptViewModel>(result);
        }

        public OperationResult<ConceptViewModel> ConceptOnly(long id)
        {
            var concept = this.conceptsService.ConceptOnly(id);
            var result = Mapper.Map<ConceptViewModel>(concept);
            return new OperationResult<ConceptViewModel>(result);
        }

        public OperationResult<ListConceptViewModel> ConceptsWith(string include)
        {
            var propertiesList = include.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            var list = this.conceptsService.ConceptsWithProperties(propertiesList);
            var listofConceptsVm = Mapper.Map<List<ConceptViewModel>>(list);
            var result = new ListConceptViewModel { Concepts = listofConceptsVm };
            return new OperationResult<ListConceptViewModel>(result);
        }

        public OperationResult<AddConceptViewModel> GetAddConceptViewModel()
        {
            var result = new AddConceptViewModel { AuthorId = 1, };
            return new OperationResult<AddConceptViewModel>(result);
        }

        public OperationResult<long> Add(AddConceptViewModel model)
        {
            var concept = Mapper.Map<AddConcept>(model);
            var id = this.conceptsService.Add(concept);
            return new OperationResult<long>(id);
        }

        public OperationResult<DeleteConceptViewModel> GetDeleteViewModel(long id)
        {
            var title = this.conceptsService.GetConceptTitle(id);
            var confirmation = "--- delete concept? ---";

            var result = new DeleteConceptViewModel { Title = title, Confirmation = confirmation, Id = id };
            return new OperationResult<DeleteConceptViewModel>(result);
        }

        public OperationResult<bool> Delete(long id)
        {
            this.conceptsService.Delete(id);
            var result = new OperationResult<bool>(true);
            return result;
        }

        public OperationResult<UpdateConceptViewModel> GetEditConceptViewModel(long id)
        {
            var model = this.conceptsService.GetConceptWithTags(id);
            var viewmodel = Mapper.Map<UpdateConceptViewModel>(model);
            return new OperationResult<UpdateConceptViewModel>(viewmodel);
        }

        public OperationResult<bool> UpdateConcept(UpdateConceptViewModel model, ClaimsPrincipal currentUser)
        {
            var idString = currentUser.Claims.First(x => x.Type == ToBeImplementedClaims.IdClaim).Value;
            var idValue = long.Parse(idString);

            OperationResult<bool> result = null;
            if (model.AuthorId != idValue)
            {
                result = new OperationResult<bool>(
                    false,
                    false,
                    "--- you will not edit concept not authored by you ---");
                return result;
            }
            
            var updateConcept = Mapper.Map<UpdateConcept>(model);
            this.conceptsService.UpdateConcept(updateConcept);
            result = new OperationResult<bool>(true);
            return result;
        }
    }
}