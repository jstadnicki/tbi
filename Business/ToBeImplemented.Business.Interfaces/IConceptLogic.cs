namespace ToBeImplemented.Business.Interfaces
{
    using ToBeImplemented.Domain.ViewModel;
    using ToBeImplemented.Domain.ViewModel.Concepts;

    public interface IConceptLogic
    {
        ListConceptViewModel List();
        ListConceptViewModel ConceptsOnly();
        ListConceptViewModel ConceptsWith(string include);

        ConceptViewModel Details(long id);
        ConceptViewModel ConceptOnly(long id);

        AddConceptViewModel GetAddConceptViewModel();

        long Add(AddConceptViewModel model);

        DeleteConceptViewModel GetDeleteViewModel(long id);

        void Delete(long id);

        UpdateConceptViewModel GetEditConceptViewModel(long id);

        void UpdateConcept(UpdateConceptViewModel model);

    }
}