namespace ToBeImplemented.Service.Implementations.Tests
{
    using ToBeImplemented.Domain.Model.Users;

    public static class RegisterUserModelFactory
    {
        public static RegisterUser CreateValid()
        {
            var result = new RegisterUser
                             {
                                 DisplayName = "ru-test-display-name",
                                 Email = "ru-test-email",
                                 Login = "ru-test-login",
                                 PasswordHash = "ru-test-password-hash"
                             };

            return result;
        }
    }
}