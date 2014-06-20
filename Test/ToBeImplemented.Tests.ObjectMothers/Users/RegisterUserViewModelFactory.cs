namespace ToBeImplemented.Tests.ObjectMothers.Users
{
    using System;

    using ToBeImplemented.Domain.ViewModel;
    using ToBeImplemented.Domain.ViewModel.Users;

    public class RegisterUserViewModelFactory
    {
        public static RegisterUserViewModel CreateValid()
        {
            var result = new RegisterUserViewModel
                             {
                                 ChallengeType = ChallengeType.CharactersOnly,
                                 DisplayName = "ruvm-test-display-name",
                                 Email = "ruvm-test-email",
                                 Username = "ruvm-test-login-name",
                                 Password = "ruvm-test-password",
                                 PasswordConfirmation = "tvm-test-password",
                                 SecurityChallengeText = "12a",
                                 SecurityResult = "a",
                             };

            return result;
        }
    }
}