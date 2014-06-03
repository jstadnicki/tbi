namespace ToBeImplemented.Domain.Model
{
    using System;

    using ToBeImplemented.Domain.Model.Users;

    public class Comment : ITbiEntity
    {
        public long Id { get; set; }
        public string Text { get; set; }

        public virtual User Author { get; set; }
        public long AuthorId { get; set; }

        public DateTime Created { get; set; }

        public long ConceptId { get; set; }

        public virtual Concept Concept { get; set; }
    }
}