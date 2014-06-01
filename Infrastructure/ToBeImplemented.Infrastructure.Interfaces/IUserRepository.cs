namespace ToBeImplemented.Infrastructure.Interfaces
{
    using ToBeImplemented.Domain.Model;
    using ToBeImplemented.Domain.Model.Users;

    public interface IUserRepository
    {
        long RegisterUser(RegisterUser registerUser);
        User GetUser(long id);
    }
}