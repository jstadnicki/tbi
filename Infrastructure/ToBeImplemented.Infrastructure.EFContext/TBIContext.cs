namespace ToBeImplemented.Infrastructure.EFContext
{
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;

    using ToBeImplemented.Domain.Model;

    public class TbiContext : DbContext, ITbiContext
    {
        public TbiContext()
            : base("tbi")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Concept>()
                .HasMany(x => x.Tags)
                .WithMany(x => x.Concepts)
                .Map(
                m =>
                {
                    m.MapLeftKey("ConceptId");
                    m.MapRightKey("TagId");
                    m.ToTable("ConceptsTags");
                });

            modelBuilder.Entity<Tag>().HasMany(x => x.Concepts).WithMany(x => x.Tags).Map(
                m =>
                {
                    m.MapLeftKey("TagId");
                    m.MapRightKey("ConceptId");
                    m.ToTable("ConceptsTags");
                });
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Concept> Concepts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PasswordReset> PasswordResets { get; set; }
        public DbSet<UserConceptVote> UsersConceptsVotes { get; set; }

        IQueryable<User> ITbiContext.Users
        { get { return this.Users; } }

        IQueryable<Concept> ITbiContext.Concepts
        { get { return this.Concepts; } }

        IQueryable<Comment> ITbiContext.Comments
        { get { return this.Comments; } }

        IQueryable<Tag> ITbiContext.Tags
        { get { return this.Tags; } }

        IQueryable<PasswordReset> ITbiContext.PasswordResets
        { get { return this.PasswordResets; } }

        IQueryable<UserConceptVote> ITbiContext.UsersConceptsVotes
        { get { return this.UsersConceptsVotes; } }

        public async Task<int> Save()
        { return await this.SaveChangesAsync(); }
    }
}
