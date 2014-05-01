namespace ToBeImplemented.Infrastructure.Repository
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using ToBeImplemented.Domain.Model;
    using ToBeImplemented.Infrastructure.EFContext;

    public interface IConceptRepository
    {
        List<Concept> GetAllConceptsWithAllCollections();
    }

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
    }
}