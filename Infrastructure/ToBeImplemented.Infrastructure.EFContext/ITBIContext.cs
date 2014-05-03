namespace ToBeImplemented.Infrastructure.EFContext
{
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;

    using ToBeImplemented.Domain.Model;

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
