namespace ToBeImplemented.Common.Data
{
    using System.Collections.Generic;
    using System.Linq;

    public class OperationResult<T>
    {
        public OperationResult(T data, bool success, List<string> errors)
        {
            this.Data = data;
            this.Success = success;
            this.Errors = errors;
        }

        public OperationResult(T data)
            : this(data, true, Enumerable.Empty<string>().ToList())
        { }

        public OperationResult(T data, bool success, string error) :
            this(data, success, new List<string> { error })
        { }

        public T Data { get; set; }
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
    }

    public static class ToBeImplementedClaims
    {
        public static string UsernameClaim = "username";
        public static string DisplayNameClaim = "displayname";
        public static string EmailClaim = "email";
        public static string IdClaim = "id";
        public static string LastLoginDateTimeClaim = "lastlogindatetime";
    }
}
