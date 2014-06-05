namespace ToBeImplemented.Domain.Model.Users
{
    using System;

    public class RegisterUser
    {
        public string Login { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime RegisterDateTime { get; set; }
    }
}