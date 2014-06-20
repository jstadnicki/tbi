namespace ToBeImplemented.Tests.ObjectMothers.Users
{
    using System;

    using ToBeImplemented.Domain.ViewModel.Users;

    public static class LoginViewModelFactory
    {
        public static LoginViewModel CreateValid()
        {
            var result = new LoginViewModel
                             {
                                 Password = "test-lvm-password",
                                 RememberMe = false,
                                 UserName = "test-lvm-username"
                             };

            return result;
        }
    }
}