﻿namespace ToBeImplemented.Domain.Model
{
    using System.Collections.Generic;

    public class User : ITbiEntity
    {
        public long Id { get; set; }
        public string Login { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public virtual List<Concept> Concepts { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<UserConceptVote> UserConceptVotes { get; set; }
    }
}