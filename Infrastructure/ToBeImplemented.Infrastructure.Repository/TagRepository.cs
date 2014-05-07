namespace ToBeImplemented.Infrastructure.Repository
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using ToBeImplemented.Domain.Model;
    using ToBeImplemented.Infrastructure.EFContext;

    public class TagRepository : ITagRepository
    {
        private readonly ITbiContext tbiContext;

        public TagRepository(ITbiContext tbiContext)
        {
            this.tbiContext = tbiContext;
        }

        public List<Tag> GetTags(List<string> textTags)
        {
            var found = this.tbiContext
                .Tags
                .Include(x => x.Concepts)
                .Where(x => textTags.Contains(x.Text)).ToList();

            var newTags =
                textTags.Where(x => found.Select(f => f.Text).Contains(x) == false)
                    .Select(x => new Tag { Concepts = new List<Concept>(), Id = 0, Text = x })
                    .ToList();

            var result = found.Concat(newTags).ToList();

            return result;
        }
    }
}