namespace ToBeImplemented.Infrastructure.EFContext
{
    using System.Linq;
    using System.Threading.Tasks;

    using ToBeImplemented.Domain.Model;

    public interface ITbiContext
    {
        IQueryable<User> Users { get;  }
        IQueryable<Concept> Concepts { get;  }
        IQueryable<Comment> Comments { get;  }
        IQueryable<Tag> Tags { get; }
        IQueryable<PasswordReset> PasswordResets { get;  }
        IQueryable<UserConceptVote> UsersConceptsVotes { get;  }

        Task<int> Save();
    }
}
