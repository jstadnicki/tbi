namespace ToBeImplemented.Business.ViewModel.Concepts
{
    using System.ComponentModel.DataAnnotations;

    public class UpdateConceptViewModel
    {
        [Required]
        public long Id { get; set; }
        
        [Required]
        public string Title { get; set; }
        
        [Required]
        public string Description { get; set; }
        
        [Required]
        public long AuthorId { get; set; }

        public string Tags { get; set; }
    }
}