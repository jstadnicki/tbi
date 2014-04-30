namespace ToBeImplemented.Domain.Model
{
    public class Comment : ITbiEntity
    {
        public long Id { get; set; }
        public string Text { get; set; }

        public User Author { get; set; }
        public long AuthorId { get; set; }
    }
}