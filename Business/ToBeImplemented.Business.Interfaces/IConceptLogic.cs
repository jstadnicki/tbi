namespace ToBeImplemented.Business.Interfaces
{
    using System.Security.Claims;

    using ToBeImplemented.Common.Data;
    using ToBeImplemented.Domain.ViewModel;
    using ToBeImplemented.Domain.ViewModel.Concepts;

    public interface IConceptLogic
    {
        OperationResult<ListConceptViewModel> List();
        OperationResult<ListConceptViewModel>ConceptsOnly();
        OperationResult<ListConceptViewModel> ConceptsWith(string include);

        OperationResult<ConceptViewModel> Details(long id);
        OperationResult<ConceptViewModel> ConceptOnly(long id);

        OperationResult<AddConceptViewModel> GetAddConceptViewModel();

        OperationResult<long> Add(AddConceptViewModel model);

        OperationResult<DeleteConceptViewModel> GetDeleteViewModel(long id);

        OperationResult<bool> Delete(long id);

        OperationResult<UpdateConceptViewModel> GetEditConceptViewModel(long id);

        OperationResult<bool> UpdateConcept(UpdateConceptViewModel model, ClaimsPrincipal currentUser);

    }
}