namespace ToBeImplemented.Tests.ObjectMothers.Users
{
    using ToBeImplemented.Business.ViewModel.Users;

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