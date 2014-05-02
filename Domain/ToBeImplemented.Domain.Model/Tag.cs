namespace ToBeImplemented.Domain.Model
{
    using System.Collections.Generic;

    public class Tag : ITbiEntity
    {
        public long Id { get; set; }
        public string Text { get; set; }

        public virtual List<Concept> Concepts { get; set; }
    }
}