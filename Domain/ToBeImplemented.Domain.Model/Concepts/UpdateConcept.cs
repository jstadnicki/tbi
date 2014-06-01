namespace ToBeImplemented.Domain.Model
{
    using System.Collections.Generic;

    public class UpdateConcept
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public long AuthorId { get; set; }

        public List<string> Tags { get; set; }
    }
}