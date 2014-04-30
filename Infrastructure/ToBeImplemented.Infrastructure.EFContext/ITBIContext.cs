namespace ToBeImplemented.Infrastructure.EFContext
{
    using System.Linq;
    using System.Threading.Tasks;

    using ToBeImplemented.Domain.Model;

    public interface ITbiContext
    {
        IQueryable<User> Users { get; set; }
        IQueryable<Concept> Concepts { get; set; }
        IQueryable<Comment> Comments { get; set; }
        IQueryable<Tag> Tags { get; set; }
        IQueryable<PasswordReset> PasswordResets { get; set; }
        IQueryable<UserConceptVote> UsersConceptsVotes { get; set; }

        Task<int> Save();
    }
}
