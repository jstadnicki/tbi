namespace ToBeImplemented.Tests.ObjectMothers.Concepts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using ToBeImplemented.Domain.Model;
    using ToBeImplemented.Tests.ObjectMothers.Users;

    public static class ConceptModelFactory
    {
        public static List<Concept> CreateFull(int count)
        {
            var author = UserModelFactory.Create();
            var tag = TagModelFactory.Create();
            var comment = CommentModelFactory.Create();
            var now = new DateTime(2003, 4, 4);
            var concept = new Concept
                              {
                                  Author = author,
                                  AuthorId = author.Id,
                                  Created = now,
                                  Comments = Enumerable.Repeat(comment, 4).ToList(),
                                  Description = "test-concept-description",
                                  DisplayCount = 43,
                                  EditCount = 33,
                                  Id = 322,
                                  LastUpdate = now,
                                  Tags = new List<Tag> { tag },
                                  Title = "test-concept-title",
                                  VoteDown = 3,
                                  VoteUp = 44
                              };
            concept.Author.Concepts.Add(concept);

            return Enumerable.Repeat(concept, count).ToList();
        }

        public static Concept Create(long id = 3333)
        {
            var now = new DateTime(2014, 1, 1);
            var result = new Concept
                             {
                                 Author = null,
                                 AuthorId = 321,
                                 Comments = null,
                                 Created = now,
                                 Description = "test-concept-description",
                                 DisplayCount = 3,
                                 EditCount = 2,
                                 Id = id,
                                 LastUpdate = now,
                                 Tags = null,
                                 Title = "test-concept-title",
                                 VoteDown = 3,
                                 VoteUp = 2
                             };

            return result;
        }

        public static Concept CreateWithTags(long id = 443)
        {
            var t1 = TagModelFactory.Create(1, "tag-1");
            var t2 = TagModelFactory.Create(2, "tag-1");
            var t3 = TagModelFactory.Create(3, "tag-1");

            var now = new DateTime(2014, 1, 1);
            var result = new Concept
            {
                Author = null,
                AuthorId = 321,
                Comments = null,
                Created = now,
                Description = "test-concept-description",
                DisplayCount = 3,
                EditCount = 2,
                Id = id,
                LastUpdate = now,
                Tags = new List<Tag> { t1, t2, t3 },
                Title = "test-concept-title",
                VoteDown = 3,
                VoteUp = 2
            };

            return result;
        }
    }
}