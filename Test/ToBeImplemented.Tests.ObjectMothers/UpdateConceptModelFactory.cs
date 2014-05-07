namespace ToBeImplemented.Tests.ObjectMothers
{
    using System.Collections.Generic;

    using ToBeImplemented.Domain.Model;

    public static class UpdateConceptModelFactory
    {
        public static UpdateConcept CreateValidWithoutTags(long id = 4343)
        {
            var result = new UpdateConcept
                             {
                                 AuthorId = 15,
                                 Description = "test-edit-concept-description-view-model",
                                 Id = id,
                                 Tags = null,
                                 Title = "test-edit-concept-title-view-model"
                             };

            return result;
        }

        public static UpdateConcept CreateWithTags(int id = 444)
        {
            var result = new UpdateConcept
            {
                AuthorId = 15,
                Description = "test-edit-concept-description-view-model",
                Id = id,
                Tags = new List<string> { "tag;mark;concept" },
                Title = "test-edit-concept-title-view-model"
            };

            return result;
        }
    }
}