using System;

namespace Common
{
    public static class TimeUtil
    {
        public static long GetCurrentTimeMillis()
        {
            return DateTime.Now.GetTimeMillis();
        }

        public static long GetTimeMillis(this DateTime date)
        {
            return (long)(date - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
        }
    }
}
