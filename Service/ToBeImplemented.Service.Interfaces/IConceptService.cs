namespace ToBeImplemented.Service.Interfaces
{
    using System.Collections.Generic;

    using ToBeImplemented.Domain.Model;

    public interface IConceptService
    {
        List<Concept> GetAllConceptsWithAllCollections();

        Concept Details(long id);

        long Add(AddConcept concept);

        string GetConceptTitle(long id);

        void Delete(long id);

        Concept GetConceptWithTags(long id);

        void UpdateConcept(UpdateConcept concept);
    }
}
