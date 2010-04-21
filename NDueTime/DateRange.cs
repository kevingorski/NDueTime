using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NDueTime
{
	public class DateRange
	{
		public DateTime Start { get; private set; }
		public DateTime End { get; private set; }
		public TimeSpan Duration { get { return End - Start; } }

		public DateRange(DateTime start, DateTime end)
		{
			if (end < start)
			{
				throw new ArgumentOutOfRangeException("end", "End must be greater than or equal to start.");
			}

			Start = start;
			End = end;
		}

		public bool Contains(DateTime dateTime)
		{
			return dateTime.IsBetween(Start, End);
		}

		public bool Contains(DateRange dateRange)
		{
			return Contains(dateRange.Start) && Contains(dateRange.End);
		}

		public bool Overlaps(DateRange dateRange)
		{
			return Contains(dateRange.Start) || Contains(dateRange.End);
		}
	}
}
