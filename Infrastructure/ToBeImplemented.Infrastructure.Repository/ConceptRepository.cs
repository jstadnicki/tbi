﻿namespace ToBeImplemented.Infrastructure.Repository
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using ToBeImplemented.Domain.Model;
    using ToBeImplemented.Infrastructure.EFContext;

    public class ConceptRepository : IConceptRepository
    {
        private readonly ITbiContext tbiContext;

        public ConceptRepository(ITbiContext tbiContext)
        {
            this.tbiContext = tbiContext;
        }

        public List<Concept> GetAllConceptsWithAllCollections()
        {
            var result = this.tbiContext.Concepts
                .Include(x => x.Author)
                .Include(x => x.Tags)
                .Include(x => x.Comments)
                .ToList();

            return result;
        }

        public Concept Details(long id)
        {
            var result = this.tbiContext
                .Concepts
                .Include(i => i.Author)
                .Include(i => i.Comments)
                .Include(i => i.Tags)
                .Single(x => x.Id == id);
            return result;
        }

        public long Add(Concept concept)
        {
            this.tbiContext.Concepts.Add(concept);
            this.tbiContext.Save();
            return concept.Id;
        }

        public string GetConceptTitle(long id)
        {
            var result = this.tbiContext.Concepts.Where(x => x.Id == id).Select(x => x.Title).Single();
            return result;
        }

        public void Delete(long id)
        {
            var concept = this.tbiContext.Concepts.Where(x => x.Id == id).First();
            this.tbiContext.Concepts.Remove(concept);
            this.tbiContext.Save();
        }

        public Concept GetConceptWithTags(long id)
        {
            var concept = this.tbiContext.Concepts.First(x => x.Id == id);
            return concept;
        }
    }
}