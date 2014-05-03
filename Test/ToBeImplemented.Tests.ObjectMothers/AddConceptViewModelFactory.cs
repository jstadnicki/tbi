namespace ToBeImplemented.Tests.ObjectMothers
{
    using ToBeImplemented.Domain.ViewModel;

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
    }
}