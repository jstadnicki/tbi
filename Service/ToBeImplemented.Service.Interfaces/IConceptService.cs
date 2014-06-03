namespace ToBeImplemented.Service.Interfaces
{
    using System.Collections.Generic;

    using ToBeImplemented.Domain.Model;

    public interface IConceptService
    {
        List<Concept> GetAllConceptsWithAllCollections();
        List<Concept> ConceptsOnly();
        List<Concept> ConceptsWithProperties(IEnumerable<string> propertiesList);

        Concept Details(long id);
        Concept ConceptOnly(long id);

        long Add(AddConcept concept);

        string GetConceptTitle(long id);

        void Delete(long id);

        Concept GetConceptWithTags(long id);

        void UpdateConcept(UpdateConcept concept);
    }
}
