namespace ToBeImplemented.Tests.ObjectMothers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    using ToBeImplemented.Domain.Model;

    public static class ConceptModelFactory
    {
        public static List<Concept> CreateFull(int count)
        {
            var author = UserModelFactory.Create();
            var tag = TagModelFactory.Create();
            var comment = CommentModelFactory.Create();
            var concept = new Concept
                              {
                                  Author = author,
                                  AuthorId = author.Id,
                                  Created = DateTime.Now,
                                  Comments = Enumerable.Repeat(comment, 4).ToList(),
                                  Description = "test-concept-description",
                                  DisplayCount = 43,
                                  EditCount = 33,
                                  Id = 322,
                                  LastUpdate = DateTime.Now,
                                  Tags = new List<Tag> { tag },
                                  Title = "test-concept-title",
                                  VoteDown = 3,
                                  VoteUp = 44
                              };
            concept.Author.Concepts.Add(concept);

            return Enumerable.Repeat(concept, count).ToList();
        }
    }

    public class CommentModelFactory
    {
        public static Comment Create()
        {
            var author = UserModelFactory.Create();
            var result = new Comment { Author = author, AuthorId = author.Id, Id = 99876, Text = "test-comment-text" };

            return result;
        }
    }
}