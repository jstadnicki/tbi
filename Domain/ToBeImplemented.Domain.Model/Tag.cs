namespace ToBeImplemented.Domain.Model
{
    public class Tag : ITbiEntity
    {
        public long Id { get; private set; }
        public string Text { get; set; }
    }
}