namespace ToBeImplemented.Domain.Model.Users
{
    using System;

    public class RegisterUser
    {
        public string UserName { get; set; }
        public string Displayname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime RegisterDateTime { get; set; }
    }
}