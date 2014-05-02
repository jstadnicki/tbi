namespace ToBeImplemented.Domain.ViewModel
{
    using System;
    using System.Collections.Generic;

    public class ConceptViewModel
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

        public AuthorViewModel Author { get; set; }
        public long AuthorId { get; set; }

        public List<TagViewModel> Tags { get; set; }

        public List<CommentViewModel> Comments { get; set; }
    }

    public class CommentViewModel
    {
        public long Id { get; set; }
        public string Text { get; set; }

        public string AuthorDisplayName { get; set; }
        public long AuthorId { get; set; }
    }

    public class TagViewModel
    {
        public long Id { get; set; }
        public string Text { get; set; }

        public List<ConceptViewModel> Concepts { get; set; }
    }

    public class AuthorViewModel
    {
        public long Id { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
    }
}