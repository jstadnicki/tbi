namespace ToBeImplemented.Infrastructure.Repository
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;

    using ToBeImplemented.Domain.Model.Users;
    using ToBeImplemented.Infrastructure.EFContext;

    public class UserRepository : IUserPasswordStore<User, long>
    {
        private readonly ITbiContext tbiContext;

        public UserRepository(ITbiContext tbiContext)
        {
            this.tbiContext = tbiContext;
        }

        public void Dispose()
        {
            /* empty on purpose */
        }

        public Task CreateAsync(User user)
        {
            var t = Task<User>.Factory.StartNew(
                () =>
                {
                    this.tbiContext.Users.Add(user);
                    this.tbiContext.Save();
                    return user;
                });

            return t;
        }

        public Task UpdateAsync(User user)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(User user)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> FindByIdAsync(long userId)
        {
            return Task.Run(() => this.tbiContext.Users.FirstOrDefault(x => x.Id == userId));
        }

        public Task<User> FindByNameAsync(string userName)
        {
            return Task.Run(() => this.tbiContext.Users.FirstOrDefault(x => x.UserName == userName));
        }

        public Task SetPasswordHashAsync(User user, string passwordHash)
        {
            return Task.Run(() => user.PasswordHash = passwordHash);
        }

        public Task<string> GetPasswordHashAsync(User user)
        {
            return Task.FromResult(user.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(User user)
        {
            return Task.FromResult(string.IsNullOrEmpty(user.PasswordHash));
        }
    }
}