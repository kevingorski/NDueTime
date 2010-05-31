using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NDueTime
{
	public static class RelativeDateTime
	{
		/*
		 * Supported phrases:
		 *	Now (Date & Time)
		 *	Dates
		 *		Today (implied default)
		 *		Tomorrow
		 *		[Day of Week]
		 *		Next [Day of Week]
		 *		Last [Day of Week]
		 *	Time
		 *		at [Time of Day]
		 *		[Time of Day] [Date]
		 */

		public static DateTime Parse(string phrase)
		{
			DateTime? result = null;

			phrase = phrase.ToLowerInvariant();

			if (SearchAndRemove(ref phrase, "now"))
			{
				result = DateTime.Now;
			}
			else if (SearchAndRemove(ref phrase, "today"))
			{
				result = DateTime.Today;
			}
			else if (SearchAndRemove(ref phrase, "tomorrow"))
			{
				result = DateTime.Today.AddDays(1);
			}
			else
			{
				result = ParseDayOfWeek(ref phrase);
			}

			if (result == null)
			{
				result = DateTime.Today;
			}

			return result.Value + ParseTimeOfDay(phrase);
		}

		private static TimeSpan ParseTimeOfDay(string phrase)
		{
			TimeSpan timeOfDay = new TimeSpan();
			TimeSpan offset = new TimeSpan();
			DateTime parsedValue;

			// Remove some common phrase noise
			phrase = phrase.Replace(" at ", String.Empty);
			phrase = phrase.Replace(" on ", String.Empty);
			phrase = phrase.Replace(" past ", String.Empty);

			if (SearchAndRemove(ref phrase, "quarter"))
			{
				offset = TimeSpan.FromMinutes(15);
			}
			else if(SearchAndRemove(ref phrase, "half"))
			{
				offset = TimeSpan.FromMinutes(30);
			}

			if(SearchAndRemove(ref phrase, "until"))
			{
				offset = offset.Negate();
			}

			if (SearchAndRemove(ref phrase, "noon"))
			{
				timeOfDay = TimeSpan.FromHours(12);
			}
			else if (DateTime.TryParse(phrase, out parsedValue))
			{
				timeOfDay = parsedValue.TimeOfDay;
			}

			return timeOfDay + offset;
		}

		private static DateTime? ParseDayOfWeek(ref string phrase)
		{
			DateTime searchDate = DateTime.Today;
			bool futureDate = true;
			DateTime? result = null;

			if (SearchAndRemove(ref phrase, "next"))
			{
				searchDate = searchDate.AddDays(7);
			}
			else if (SearchAndRemove(ref phrase, "last"))
			{
				futureDate = false;
				searchDate = searchDate.AddDays(-7);
			}
			else
			{
				searchDate = searchDate.AddDays(1);
			}

			foreach (DayOfWeek dayOfWeek in Enum.GetValues(typeof(DayOfWeek)))
			{
				if (SearchAndRemove(ref phrase, Enum.GetName(typeof(DayOfWeek), dayOfWeek).ToLowerInvariant()))
				{
					while (searchDate.DayOfWeek != dayOfWeek)
						searchDate = searchDate.AddDays((futureDate ? 1 : -1) * 1);

					result = searchDate;

					break;
				}
			}

			return result;
		}

		private static bool SearchAndRemove(ref string phrase, string search)
		{
			if (phrase.Contains(search))
			{
				phrase = phrase.Replace(search, String.Empty);

				return true;
			}

			return false;
		}
	}
}
