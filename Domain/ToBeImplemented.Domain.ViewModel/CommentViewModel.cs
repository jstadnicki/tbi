namespace ToBeImplemented.Domain.ViewModel
{
    public class CommentViewModel
    {
        public long Id { get; set; }
        public string Text { get; set; }

        public string AuthorDisplayName { get; set; }
        public long AuthorId { get; set; }
    }
}