namespace ToBeImplemented.Infrastructure.Repository
{
    using System.Collections.Generic;

    using ToBeImplemented.Domain.Model;

    public interface IConceptRepository
    {
        List<Concept> GetAllConceptsWithAllCollections();
        List<Concept> ConceptsOnly();

        Concept Details(long id);
        Concept ConceptOnly(long id);

        long Add(Concept concept);

        string GetConceptTitle(long id);

        void Delete(long id);

        Concept GetConceptWithTags(long id);

        void Save();

    }
}