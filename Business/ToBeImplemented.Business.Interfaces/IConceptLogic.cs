namespace ToBeImplemented.Business.Interfaces
{
    using ToBeImplemented.Domain.ViewModel;

    public interface IConceptLogic
    {
        ListConceptViewModel List();
        ListConceptViewModel ConceptsOnly();

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