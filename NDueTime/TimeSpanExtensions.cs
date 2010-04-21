using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NDueTime
{
	public static class TimeSpanExtensions
	{
		public static TimeSpan And(this TimeSpan first, TimeSpan second)
		{
			return first + second;
		}

		public static DateTime Before(this TimeSpan relativeTime, DateTime relativeTo)
		{
			return relativeTo.Add(-relativeTime);
		}

		public static DateTime Ago(this TimeSpan relativeTime)
		{
			return Before(relativeTime, DateTime.Now);
		}

		public static DateTime After(this TimeSpan relativeTime, DateTime relativeTo)
		{
			return relativeTo.Add(relativeTime);
		}

		public static DateTime FromNow(this TimeSpan relativeTime)
		{
			return After(relativeTime, DateTime.Now);
		}
	}
}
