namespace ToBeImplemented.Domain.ViewModel.Concepts
{
    using System.ComponentModel.DataAnnotations;

    public class AddConceptViewModel
    {
        [Required]
        public long AuthorId { get; set; }
        
        [Required]
        public string Title { get; set; }
        
        [Required]
        public string Description { get; set; }
 
        public string Tags { get; set; }
    }
}