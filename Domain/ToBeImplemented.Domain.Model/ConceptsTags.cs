namespace ToBeImplemented.Domain.Model
{
    using System.Collections.Specialized;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ConceptsTags")]
    public class ConceptsTags
    {
        [Key, Column(Order = 0)]
        public long ConceptId { get; set; }
        [Key, Column(Order = 1)]
        public long TagId { get; set; }

        public virtual Concept Concept { get; set; }
        public virtual Tag Tag { get; set; }
    }
}