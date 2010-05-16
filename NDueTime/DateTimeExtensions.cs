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

		private const int SecondsPerMinute = 60;
		private const int SecondsPerHour = SecondsPerMinute * 60;
		private const int SecondsPerDay = SecondsPerHour * 24;
		private const int SecondsPerWeek = SecondsPerDay * 7;

		public static string ToRelativeTimeString(this DateTime subject)
		{
			string result;
			TimeSpan difference = subject - DateTime.Now;
			double totalSeconds = difference.TotalSeconds;
			bool inTheFuture = totalSeconds > 0;

			totalSeconds = Math.Abs(totalSeconds);

			if (totalSeconds < 5)
			{
				result = "A few moments";
			}
			else
			{
				int value;
				string units;

				if (totalSeconds < SecondsPerMinute)
				{
					value = (int) totalSeconds;
					units = "seconds";
				}
				else if (totalSeconds < SecondsPerHour)
				{
					value = (int) Math.Round(totalSeconds/SecondsPerMinute);
					units = "minutes";
				}
				else if (totalSeconds < SecondsPerDay)
				{
					value = (int) totalSeconds/SecondsPerHour;
					units = "hours";
				}
				else if (totalSeconds < SecondsPerWeek)
				{
					value = (int) totalSeconds/SecondsPerDay;
					units = "days";
				}
				else
				{
					value = (int) totalSeconds/SecondsPerWeek;
					units = "weeks";
				}

				result = String.Format("{0} {1}", value, units);
			}

			return result + (inTheFuture ? " from now" : " ago");
		}
	}
}
