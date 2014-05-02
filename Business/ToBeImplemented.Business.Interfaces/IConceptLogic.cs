namespace ToBeImplemented.Business.Interfaces
{
    using ToBeImplemented.Domain.ViewModel;

    public interface IConceptLogic
    {
        ListConceptViewModel List();

        ConceptViewModel Details(long id);
    }
}