namespace ToBeImplemented.Service.Implementations
{
    using System.Collections.Generic;

    using ToBeImplemented.Domain.Model;
    using ToBeImplemented.Infrastructure.Repository;
    using ToBeImplemented.Service.Interfaces;

    public class ConceptService : IConceptService
    {
        private readonly IConceptRepository conceptRepository;

        public ConceptService(IConceptRepository conceptRepository)
        {
            this.conceptRepository = conceptRepository;
        }

        public List<Concept> GetAllConceptsWithAllCollections()
        {
            var result = this.conceptRepository.GetAllConceptsWithAllCollections();
            return result;
        }
    }
}