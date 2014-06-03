namespace ToBeImplemented.Tests.ObjectMothers.Users
{
    using System.Collections.Generic;

    using ToBeImplemented.Domain.Model;
    using ToBeImplemented.Domain.Model.Users;

    public class UserModelFactory
    {
        public static User Create()
        {
            var result = new User
                             {
                                 Comments = new List<Comment>(),
                                 Concepts = new List<Concept>(),
                                 DisplayName = "test-user-display-name",
                                 Email = "test@user.email",
                                 Id = 99,
                                 Login = "test-user-login",
                                 PasswordHash = "test-user-password-hash"
                             };

            return result;
        }
    }
}