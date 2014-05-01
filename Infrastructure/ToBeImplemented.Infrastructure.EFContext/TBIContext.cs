namespace ToBeImplemented.Infrastructure.EFContext
{
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;

    using ToBeImplemented.Domain.Model;

    public class TbiContext : DbContext, ITbiContext
    {
        public IQueryable<User> Users { get; set; }
        public IQueryable<Concept> Concepts { get; set; }
        public IQueryable<Comment> Comments { get; set; }
        public IQueryable<Tag> Tags { get; set; }
        public IQueryable<PasswordReset> PasswordResets { get; set; }
        public IQueryable<UserConceptVote> UsersConceptsVotes { get; set; }

        public async Task<int> Save()
        {
            return await this.SaveChangesAsync();
        }
    }
}
