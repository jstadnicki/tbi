namespace ToBeImplemented.Service.Interfaces
{
    using ToBeImplemented.Domain.Model.Users;

    public interface IRegisterService
    {
        long RegisterUser(RegisterUser isAny);
    }
}
