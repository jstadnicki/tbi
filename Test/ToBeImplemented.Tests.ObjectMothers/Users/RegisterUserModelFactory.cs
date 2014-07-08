namespace ToBeImplemented.Tests.ObjectMothers.Users
{
    using System;

    using ToBeImplemented.Service.Model.Users;

    public static class RegisterUserModelFactory
    {
        public static RegisterUser CreateValid()
        {
            var result = new RegisterUser
                             {
                                 Displayname = "ru-test-display-name",
                                 Email = "ru-test-email",
                                 UserName = "ru-test-login",
                                 Password = "ru-test-password",
                                 RegisterDateTime = new DateTime(2000, 1, 1)
                             };

            return result;
        }
    }
}