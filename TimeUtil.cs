using System;
using System.Text;

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

    public static class ByteUtil
    {
        public static string ToHexString(this byte[] bytes, int start = 0, int len = -1)
        {
            if(len < 0)
            {
                len = bytes.Length;
            }
            var ret = new StringBuilder();
            for(int i = start, j = 0; i < bytes.Length && j < len; i++, j++)
            {
                ret.AppendFormat("{0:x2} ", bytes[i]);
            }
            return ret.ToString();
        }
    }
}
