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
}
