namespace ToBeImplemented.Service.Interfaces
{
    using ToBeImplemented.Domain.Model.Users;
    using ToBeImplemented.Service.Model.Users;

    public interface IRegisterService
    {
        long RegisterUser(RegisterUser user);
    }
}
