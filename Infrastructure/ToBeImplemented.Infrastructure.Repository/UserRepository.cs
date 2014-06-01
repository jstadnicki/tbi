namespace ToBeImplemented.Infrastructure.Repository
{
    using System.Linq;

    using AutoMapper;

    using ToBeImplemented.Domain.Model;
    using ToBeImplemented.Domain.Model.Users;
    using ToBeImplemented.Infrastructure.EFContext;
    using ToBeImplemented.Infrastructure.Interfaces;

    public class UserRepository : IUserRepository
    {
        private readonly ITbiContext tbiContext;

        public UserRepository(ITbiContext tbiContext)
        {
            this.tbiContext = tbiContext;
        }

        public long RegisterUser(RegisterUser registerUser)
        {
            var user = Mapper.Map<User>(registerUser);
            this.tbiContext.Users.Add(user);
            this.tbiContext.Save();
            return user.Id;
        }

        public User GetUser(long id)
        {
            var result = this.tbiContext.Users.First(x => x.Id == id);
            return result;
        }
    }
}