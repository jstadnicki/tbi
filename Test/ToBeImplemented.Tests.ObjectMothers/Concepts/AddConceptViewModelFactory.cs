namespace ToBeImplemented.Tests.ObjectMothers.Concepts
{
    using ToBeImplemented.Domain.ViewModel;
    using ToBeImplemented.Domain.ViewModel.Concepts;

    public static class AddConceptViewModelFactory
    {
        public static AddConceptViewModel CreateValidWithoutTags()
        {
            var result = new AddConceptViewModel
                             {
                                 AuthorId = 44,
                                 Description = "test-add-concept-view-model-descriptions",
                                 Title = "test-add-concept-view-model-title",
                                 Tags = null
                             };

            return result;
        }

        public static AddConceptViewModel CreateWithTags()
        {
            var result = new AddConceptViewModel
            {
                AuthorId = 44,
                Description = "test-add-concept-view-model-descriptions",
                Title = "test-add-concept-view-model-title",
                Tags = "tag;mark;concept"
            };

            return result;
        }

        public static object CreateWithNullTags()
        {
            var result = new AddConceptViewModel
            {
                AuthorId = 44,
                Description = "test-add-concept-view-model-descriptions",
                Title = "test-add-concept-view-model-title",
                Tags = null,
            };
            return result;
        }
    }
}