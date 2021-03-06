namespace ToBeImplemented.Domain.Model
{
    using System;
    using System.Collections.Generic;

    using ToBeImplemented.Domain.Model.Users;

    public class Concept : ITbiEntity
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public DateTime Created { get; set; }
        public DateTime LastUpdate { get; set; }

        public long EditCount { get; set; }

        public long VoteUp { get; set; }
        public long VoteDown { get; set; }
        public long DisplayCount { get; set; }

        public virtual User Author { get; set; }
        public long AuthorId { get; set; }

        public virtual List<Tag> Tags { get; set; }
        public virtual List<Comment> Comments { get; set; } 
    }
}