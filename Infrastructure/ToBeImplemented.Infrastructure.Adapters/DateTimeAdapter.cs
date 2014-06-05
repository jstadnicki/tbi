namespace ToBeImplemented.Infrastructure.Adapters
{
    using System;
    using System.Data.SqlTypes;

    using ToBeImplemented.Infrastructure.Interfaces.Adapters;

    public class DateTimeAdapter : IDateTimeAdapter
    {
        public DateTime Now
        {
            get { return DateTime.Now; }
        }

        public DateTime MinMsSqlDate
        {
            get { return SqlDateTime.MinValue.Value; }
        }
    }
}