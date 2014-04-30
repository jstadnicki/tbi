namespace ToBeImplemented.Domain.Model
{
    using System;

    public class UserConceptVote : ITbiEntity
    {
        public long Id { get; set; }
        public long ConceptId { get; set; }
        public long UserId { get; set; }
        public DateTime ExpirationTime { get; set; }
    }
}
