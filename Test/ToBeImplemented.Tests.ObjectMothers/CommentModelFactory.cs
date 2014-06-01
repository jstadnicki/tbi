namespace ToBeImplemented.Tests.ObjectMothers
{
    using System;

    using ToBeImplemented.Domain.Model;
    using ToBeImplemented.Tests.ObjectMothers.Users;

    public class CommentModelFactory
    {
        public static Comment Create()
        {
            var author = UserModelFactory.Create();
            var now = new DateTime(1998, 5, 6);
            var result = new Comment { Author = author,
                                       AuthorId = author.Id,
                                       Id = 99876, 
                                       Created = now,
                                       Text = "test-comment-text" };

            return result;
        }
    }
}