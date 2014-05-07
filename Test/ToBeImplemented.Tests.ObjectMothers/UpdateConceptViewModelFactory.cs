namespace ToBeImplemented.Tests.ObjectMothers
{
    using ToBeImplemented.Domain.ViewModel;

    public static class UpdateConceptViewModelFactory
    {
        public static UpdateConceptViewModel CreateValidWithoutTags()
        {
            var result = new UpdateConceptViewModel
                             {
                                 AuthorId = 15,
                                 Description = "test-edit-concept-description-view-model",
                                 Id = 14,
                                 Tags = null,
                                 Title = "test-edit-concept-title-view-model"
                             };

            return result;
        }

        public static object CreateWithTags()
        {
            var result = new UpdateConceptViewModel
            {
                AuthorId = 15,
                Description = "test-edit-concept-description-view-model",
                Id = 14,
                Tags = "tag;mark;hash",
                Title = "test-edit-concept-title-view-model"
            };

            return result;
        }
    }
}