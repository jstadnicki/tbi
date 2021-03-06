﻿namespace ToBeImplemented.Infrastructure.Interfaces
{
    using System.Collections.Generic;

    using ToBeImplemented.Domain.Model;

    public interface IConceptRepository
    {
        List<Concept> GetAllConceptsWithAllCollections();
        List<Concept> ConceptsOnly();
        List<Concept> ConceptsWithProperties(IEnumerable<string> propertiesList);

        Concept Details(long id);
        Concept ConceptOnly(long id);
        Concept GetConceptWithTags(long id);

        long Add(Concept concept);

        string GetConceptTitle(long id);

        void Delete(long id);

        void Save();

        long GetConceptsCountByUserId(long authorId);
    }
}