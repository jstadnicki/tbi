namespace ToBeImplemented.Service.Interfaces
{
    public interface IUserPasswordHasher
    {
        string GetHash(string text, string salt);
    }
}