using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NDueTime
{
	// DateTime examples:
	// short	6/15/2009
	// long		Monday, June 15, 2009 
	// full (short time)	Monday, June 15, 2009 1:45 PM
	// full (long time)		Monday, June 15, 2009 1:45:30 PM
	// general (short time)	6/15/2009 1:45 PM
	// general (long time)	6/15/2009 1:45:30 PM

	// TimeSpan.TryParse
	// http://msdn.microsoft.com/en-us/library/dd992769.aspx

	// TimeSpan CustomFormatter
	// http://geekswithblogs.net/luskan/archive/2008/02/04/119285.aspx

	// FormatProviders
	// http://msdn.microsoft.com/en-us/library/26etazsy(v=VS.100).aspx#FormatProviders

	public class TimeSpanFormatProvider : IFormatProvider, ICustomFormatter
	{
		#region IFormatProvider Members

		public object GetFormat(Type formatType)
		{
			return (formatType == typeof (ICustomFormatter)) ? this : null;
		}

		#endregion

		#region ICustomFormatter Members

		public string Format(string format, object arg, IFormatProvider formatProvider)
		{
			var timeSpan = arg as TimeSpan?;

			if (!formatProvider.Equals(this) || timeSpan == null)
				return null;

			var days = (int) Math.Floor(timeSpan.Value.TotalDays);
			var hours = (int) Math.Floor((double) timeSpan.Value.Hours);
			var minutes = (int) Math.Floor((double) timeSpan.Value.Minutes);
			var seconds = (int) Math.Floor((double) timeSpan.Value.Seconds);

			return format
				.Replace("dd", days.ToString("00"))
				.Replace("d", days.ToString())
				.Replace("hh", hours.ToString("00"))
				.Replace("h", hours.ToString())
				.Replace("mm", minutes.ToString("00"))
				.Replace("m", minutes.ToString())
				.Replace("ss", seconds.ToString("00"))
				.Replace("s", seconds.ToString());
		}

		#endregion
	}
}
