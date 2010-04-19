using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NDueTime
{
    public static class IntegerExtensions
    {
        public static TimeSpan Milliseconds(this int milliseconds)
        {
            return DoubleExtensions.Milliseconds(milliseconds);
        }

        public static TimeSpan Seconds(this int seconds)
        {
            return DoubleExtensions.Seconds(seconds);
        }

        public static TimeSpan Minutes(this int minutes)
        {
            return DoubleExtensions.Minutes(minutes);
        }

        public static TimeSpan Hours(this int hours)
        {
            return DoubleExtensions.Hours(hours);
        }
    }
}
