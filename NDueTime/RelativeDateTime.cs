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

		private static bool SearchAndReplace(ref string phrase, string search)
		{
			if (phrase.Contains(search))
			{
				phrase = phrase.Replace(search, String.Empty);

				return true;
			}

			return false;
		}

		public static DateTime Parse(string phrase)
		{
			DateTime? result = null;

			phrase = phrase.ToLowerInvariant();

			if (SearchAndReplace(ref phrase, "now"))
			{
				result = DateTime.Now;
			}
			else if (SearchAndReplace(ref phrase, "today"))
			{
				result = DateTime.Today;
			}
			else if (SearchAndReplace(ref phrase, "tomorrow"))
			{
				result = DateTime.Today.AddDays(1);
			}
			else
			{
				bool futureDate = true;
				DateTime searchDate = DateTime.Today;

				if (SearchAndReplace(ref phrase, "next"))
				{
					searchDate = searchDate.AddDays(7);
				}
				else if (SearchAndReplace(ref phrase, "last"))
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
					if (SearchAndReplace(ref phrase, Enum.GetName(typeof(DayOfWeek), dayOfWeek).ToLowerInvariant()))
					{
						while (searchDate.DayOfWeek != dayOfWeek)
							searchDate = searchDate.AddDays((futureDate ? 1 : -1) * 1);

						result = searchDate;
					}
				}
			}

			if (result == null)
			{
				// Handles time of day, assumes today
				result = DateTime.Parse(phrase);
			}
			else
			{
				DateTime parsedValue;

				phrase = phrase.Replace(" at ", String.Empty);
				phrase = phrase.Replace(" on ", String.Empty);

				if (DateTime.TryParse(phrase, out parsedValue))
				{
					result = result.Value + parsedValue.TimeOfDay;
				}
			}

			return result.Value;
		}
	}
}
