namespace ToBeImplemented.Infrastructure.EFContext
{
    using System.Data.Entity;

    using ToBeImplemented.Domain.Model;
    using ToBeImplemented.Domain.Model.Users;

    public interface ITbiContext
    {
        IDbSet<User> Users { get; }
        IDbSet<Concept> Concepts { get; }
        IDbSet<Comment> Comments { get; }
        IDbSet<Tag> Tags { get; }
        IDbSet<PasswordReset> PasswordResets { get; }
        IDbSet<UserConceptVote> UsersConceptsVotes { get; }

        void Save();
    }
}
