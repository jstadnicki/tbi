namespace ToBeImplemented.Domain.ViewModel.Users
{
    using System.Collections.Generic;

    using ToBeImplemented.Domain.ViewModel.Concepts;

    public class UserProfileViewModel
    {
        public long Id { get; set; }
        public string DisplayName { get; set; }
        public virtual List<ConceptViewModel> Concepts { get; set; }
    }
}