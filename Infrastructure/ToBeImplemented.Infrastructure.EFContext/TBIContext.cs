namespace ToBeImplemented.Infrastructure.EFContext
{
    using System.Data.Entity;
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

        public IDbSet<User> Users { get; set; }
        public IDbSet<Concept> Concepts { get; set; }
        public IDbSet<Comment> Comments { get; set; }
        public IDbSet<Tag> Tags { get; set; }
        public IDbSet<PasswordReset> PasswordResets { get; set; }
        public IDbSet<UserConceptVote> UsersConceptsVotes { get; set; }

        public void Save()
        {
            this.SaveChanges();
        }
    }
}
