using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NDueTime
{
	public static class DoubleExtensions
	{
		public static TimeSpan Milliseconds(this double milliseconds)
		{
			return TimeSpan.FromMilliseconds(milliseconds);
		}

		public static TimeSpan Seconds(this double seconds)
		{
			return TimeSpan.FromSeconds(seconds);
		}

		public static TimeSpan Minutes(this double minutes)
		{
			return TimeSpan.FromMinutes(minutes);
		}

		public static TimeSpan Hours(this double hours)
		{
			return TimeSpan.FromHours(hours);
		}

		public static TimeSpan Days(this double days)
		{
			return TimeSpan.FromDays(days);
		}
	}
}
