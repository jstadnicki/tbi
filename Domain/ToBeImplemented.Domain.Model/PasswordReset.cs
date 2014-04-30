namespace ToBeImplemented.Domain.Model
{
    using System;

    public class PasswordReset : ITbiEntity
    {
        public long Id { get; set; }
        public string Token { get; set; }
        public long UserId { get; set; }
        public DateTime ExpirationTime { get; set; }
    }
}