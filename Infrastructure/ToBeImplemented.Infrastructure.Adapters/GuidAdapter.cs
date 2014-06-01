namespace ToBeImplemented.Infrastructure.Adapters
{
    using System;

    using ToBeImplemented.Infrastructure.Interfaces.Adapters;

    public class GuidAdapter : IGuidAdapter
    {
        public Guid NewGuid()
        {
            return Guid.NewGuid();
        }
    }
}