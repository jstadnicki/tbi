namespace ToBeImplemented.Infrastructure.Repository
{
    using System.Collections.Generic;

    using ToBeImplemented.Domain.Model;

    public interface IConceptRepository
    {
        List<Concept> GetAllConceptsWithAllCollections();

        Concept Details(long id);

        long Add(Concept concept);
    }
}