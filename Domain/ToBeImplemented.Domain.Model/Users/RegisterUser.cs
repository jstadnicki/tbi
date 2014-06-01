namespace ToBeImplemented.Domain.Model.Users
{
    public class RegisterUser
    {
        public string Login { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}