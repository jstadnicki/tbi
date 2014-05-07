namespace ToBeImplemented.Service.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using ToBeImplemented.Domain.Model;
    using ToBeImplemented.Infrastructure.Repository;
    using ToBeImplemented.Service.Interfaces;

    public class ConceptService : IConceptService
    {
        private readonly IConceptRepository conceptRepository;
        private readonly ITagRepository tagRepository;

        public ConceptService(IConceptRepository conceptRepository, ITagRepository tagRepository)
        {
            this.conceptRepository = conceptRepository;
            this.tagRepository = tagRepository;
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

        public Concept GetConceptWithTags(long id)
        {
            var concept = this.conceptRepository.GetConceptWithTags(id);
            return concept;
        }

        public void UpdateConcept(UpdateConcept updateConcept)
        {
            var concept = this.conceptRepository.GetConceptWithTags(updateConcept.Id);

            concept.Description = updateConcept.Description;
            concept.Title = updateConcept.Title;

            concept.LastUpdate = DateTime.Now;
            concept.EditCount++;

            var newTagList = this.tagRepository.GetTags(updateConcept.Tags);

            concept.Tags.Clear();
            concept.Tags.AddRange(newTagList);

            this.conceptRepository.Save();
        }
    }
}