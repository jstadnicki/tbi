namespace ToBeImplemented.Infrastructure.Adapters
{
    using System;

    using ToBeImplemented.Infrastructure.Interfaces.Adapters;

    public class DateTimeAdapter : IDateTimeAdapter
    {
        public DateTime Now
        {
            get { return DateTime.Now; }
        }
    }
}