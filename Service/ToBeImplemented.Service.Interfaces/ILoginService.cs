namespace ToBeImplemented.Service.Interfaces
{
    using ToBeImplemented.Common.Data;

    public interface ILoginService
    {

        object GetSaltForUserLogin(string p);

        object GetUser(string p1, string p2);
    }
}