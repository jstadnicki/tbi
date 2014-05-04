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

        public Concept Details(long id)
        {
            var result = this.conceptRepository.Details(id);
            return result;
        }

        public long Add(Concept concept)
        {
            var result = this.conceptRepository.Add(concept);
            return result;
        }

        public string GetConceptTitle(long id)
        {
            var result = this.conceptRepository.GetConceptTitle(id);
            return result;
        }

        public void Delete(long id)
        {
            this.conceptRepository.Delete(id);
        }
    }
}