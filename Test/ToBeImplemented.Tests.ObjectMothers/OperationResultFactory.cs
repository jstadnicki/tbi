namespace ToBeImplemented.Tests.ObjectMothers
{
    using ToBeImplemented.Common.Data;

    public static class OperationResultFactory<T>
    {
        public static OperationResult<T> CreateNotSuccessful()
        {
            var result = new OperationResult<T>(default(T), false, "");
            return result;
        }

        public static OperationResult<T> CreateSuccesful(T p)
        {
            var result = new OperationResult<T>(p);
            return result;
        }
    }
}