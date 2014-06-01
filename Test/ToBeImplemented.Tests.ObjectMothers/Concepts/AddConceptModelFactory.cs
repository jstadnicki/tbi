namespace ToBeImplemented.Tests.ObjectMothers.Concepts
{
    using System.Collections.Generic;

    using ToBeImplemented.Domain.Model;

    public static class AddConceptModelFactory
    {
        public static AddConcept CreateWithTags()
        {
            var result = new AddConcept
                             {
                                 AuthorId = 99,
                                 Description = "test-description-add-concept",
                                 Tags = new List<string> { "tag", "concept", "mark" },
                                 Title = "test-title-add-concept"
                             };

            return result;
        }
    }
}