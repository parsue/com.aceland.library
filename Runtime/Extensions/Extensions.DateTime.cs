using System;

namespace AceLand.Library.Extensions
{
    public static partial class Extensions
    {
        private static readonly DateTime START_DATETIME = new(1970, 1, 1, 0, 0, 0);
        private static readonly DateTime START_DATETIME_UTC = new(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static TimeSpan ToTimeSpan(this DateTime dateTime) =>
            dateTime - START_DATETIME;
        
        public static DateTime ToTimeSpan(this TimeSpan timeSpan) =>
            START_DATETIME_UTC.AddSeconds(timeSpan.TotalSeconds);

        public static DateTime ToDateTime(this float totalSeconds) =>
            START_DATETIME_UTC.AddSeconds(totalSeconds);

        public static DateTime ToDateTime(this double totalSeconds) =>
            START_DATETIME_UTC.AddSeconds(totalSeconds);
    }
}
