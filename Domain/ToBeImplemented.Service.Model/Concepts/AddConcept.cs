namespace ToBeImplemented.Service.Model.Concepts
{
    using System.Collections.Generic;

    public class AddConcept
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public long AuthorId { get; set; }
        public List<string> Tags { get; set; }
    }
}