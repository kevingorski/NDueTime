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
			string originalPhrase = (string)phrase.Clone();
			DateTime? date;
			TimeSpan? time;

			phrase = phrase.ToLowerInvariant();

			if (SearchAndRemove(ref phrase, "now"))
			{
				date = DateTime.Now;
			}
			else if (SearchAndRemove(ref phrase, "today"))
			{
				date = DateTime.Today;
			}
			else if (SearchAndRemove(ref phrase, "tomorrow"))
			{
				date = DateTime.Today.AddDays(1);
			}
			else
			{
				date = ParseDayOfWeek(ref phrase);
			}

			time = ParseTimeOfDay(phrase);

			if(!(date.HasValue || time.HasValue))
			{
				throw new FormatException(String.Format("Could not parse '{0}'", originalPhrase));
			}

			return (date ?? DateTime.Today) + (time ?? new TimeSpan());
		}

		private static TimeSpan? ParseTimeOfDay(string phrase)
		{
			TimeSpan? timeOfDay = null;
			TimeSpan? offset = null;
			DateTime parsedValue;

			// Remove some common phrase noise
			phrase = phrase.Replace(" at ", String.Empty);
			phrase = phrase.Replace(" on ", String.Empty);
			phrase = phrase.Replace(" past ", String.Empty);
			phrase = phrase.Replace(" this ", String.Empty);

			if (SearchAndRemove(ref phrase, "quarter"))
			{
				offset = TimeSpan.FromMinutes(15);
			}
			else if(SearchAndRemove(ref phrase, "half"))
			{
				offset = TimeSpan.FromMinutes(30);
			}

			if(offset.HasValue && SearchAndRemove(ref phrase, "until"))
			{
				offset = offset.Value.Negate();
			}

			if (SearchAndRemove(ref phrase, "noon"))
			{
				timeOfDay = TimeSpan.FromHours(12);
			}
			else if (DateTime.TryParse(phrase, out parsedValue))
			{
				timeOfDay = parsedValue.TimeOfDay;
			}

			if(!(timeOfDay.HasValue || offset.HasValue))
			{
				return null;
			}

			return (timeOfDay ?? new TimeSpan()) + (offset ?? new TimeSpan());
		}

		private static DateTime? ParseDayOfWeek(ref string phrase)
		{
			DateTime searchDate = DateTime.Today;
			DateTime? result = null;

			if (SearchAndRemove(ref phrase, "next"))
			{
				searchDate = searchDate.AddDays(7);
			}
			else if (SearchAndRemove(ref phrase, "last"))
			{
				searchDate = searchDate.AddDays(-7);
			}

			foreach (DayOfWeek dayOfWeek in Enum.GetValues(typeof(DayOfWeek)))
			{
				if (SearchAndRemove(ref phrase, Enum.GetName(typeof(DayOfWeek), dayOfWeek).ToLowerInvariant()))
				{
					result = searchDate.FindDayInTheSameWeek(dayOfWeek);
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
