namespace ToBeImplemented.Domain.ViewModel
{
    using System.Collections.Generic;

    public class TagViewModel
    {
        public long Id { get; set; }
        public string Text { get; set; }

        public List<ConceptViewModel> Concepts { get; set; }
    }
}