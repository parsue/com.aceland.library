using System;

namespace AceLand.Library.Extensions
{
    public static partial class Extensions
    {
        private static readonly DateTime StartDatetime = new(1970, 1, 1, 0, 0, 0);
        private static readonly DateTime StartDatetimeUtc = new(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static TimeSpan ToTimeSpan(this DateTime dateTime) =>
            dateTime - StartDatetime;
        
        public static DateTime ToDateTime(this TimeSpan timeSpan) =>
            StartDatetimeUtc.AddSeconds(timeSpan.TotalSeconds);

        public static DateTime ToDateTime(this float totalSeconds) =>
            StartDatetimeUtc.AddSeconds(totalSeconds);

        public static DateTime ToDateTime(this double totalSeconds) =>
            StartDatetimeUtc.AddSeconds(totalSeconds);
    }
}
