namespace ToBeImplemented.Business.Interfaces.Common
{
    using System.Collections.Generic;
    using System.Linq;

    public class BussinesResult<T>
    {
        public BussinesResult(T data, bool success, List<string> errors)
        {
            this.Data = data;
            this.Success = success;
            this.Errors = errors;
        }

        public BussinesResult(T data)
            : this(data, true, Enumerable.Empty<string>().ToList())
        { }

        public BussinesResult(T data, bool success, string error) :
            this(data, success, new List<string> { error })
        {

        }

        public T Data { get; set; }
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
    }
}