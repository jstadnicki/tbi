namespace ToBeImplemented.Domain.Model
{
    using System;
    using System.Collections.Generic;

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

        public User Author { get; set; }
        public long AuthorId { get; set; }

        public List<Tag> Tags { get; set; }

        public List<Comment> Comments { get; set; } 
    }
}