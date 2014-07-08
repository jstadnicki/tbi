namespace ToBeImplemented.Business.ViewModel
{
    using System.Collections.Generic;

    using ToBeImplemented.Business.ViewModel.Concepts;

    public class TagViewModel
    {
        public long Id { get; set; }
        public string Text { get; set; }

        public List<ConceptViewModel> Concepts { get; set; }
    }
}