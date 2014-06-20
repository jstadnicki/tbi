namespace ToBeImplemented.Infrastructure.Repository
{
    using Microsoft.AspNet.Identity;

    using ToBeImplemented.Domain.Model.Users;

    public class TbiUserManager : UserManager<User, long>
    {
        public TbiUserManager(IUserStore<User, long> store)
            : base(store)
        {
        }
    }
}