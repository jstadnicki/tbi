namespace ToBeImplemented.Domain.Model
{
    using System.Collections.Generic;

    public class User : ITbiEntity
    {
        public long Id { get; set; }
        public string Login { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public List<Concept> Concepts { get; set; }
        public List<Comment> Comments { get; set; } 
    }
}