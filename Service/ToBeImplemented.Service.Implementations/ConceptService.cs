namespace ToBeImplemented.Service.Implementations
{
    using System;
    using System.Collections.Generic;

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

        public List<Concept> ConceptsOnly()
        {
            var result = this.conceptRepository.ConceptsOnly();
            return result;
        }

        public Concept Details(long id)
        {
            var result = this.conceptRepository.Details(id);
            return result;
        }

        public Concept ConceptOnly(long id)
        {
            var result = this.conceptRepository.ConceptOnly(id);
            return result;
        }

        public long Add(AddConcept concept)
        {
            var tags = this.tagRepository.GetTags(concept.Tags);

            var newConcept = new Concept
                               {
                                   AuthorId = concept.AuthorId,
                                   Description = concept.Description,
                                   Title = concept.Title,
                                   Created = DateTime.Now,
                                   LastUpdate = DateTime.Now,
                                   Tags = tags
                               };

            var id = this.conceptRepository.Add(newConcept);
            return id;
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