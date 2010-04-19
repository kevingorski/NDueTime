using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NDueTime
{
    public static class DateTimeExtensions
    {
        public static bool IsBetween(this DateTime subject, DateTime first, DateTime second)
        {
            return (first <= subject && subject <= second)
                   || (second <= subject && subject <= first);
        }

        public static bool IsInTheFuture(this DateTime subject)
        {
            return subject > DateTime.Now;
        }

        public static bool IsInThePast(this DateTime subject)
        {
            return subject < DateTime.Now;
        }
    }
}
