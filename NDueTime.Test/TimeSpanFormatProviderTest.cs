using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace NDueTime.Test
{
	[TestFixture]
	public class TimeSpanFormatProviderTest
	{
		[Test]
		public void WhenFormattingDays_Format_ReturnsCorrectString()
		{
			Assert.AreEqual("1", String.Format(new TimeSpanFormatProvider(), "{0:d}", TimeSpan.FromDays(1)));
		}

		[Test]
		public void WhenFormattingHours_Format_ReturnsCorrectString()
		{
			Assert.AreEqual("1", String.Format(new TimeSpanFormatProvider(), "{0:h}", TimeSpan.FromHours(1)));
		}

		[Test]
		public void WhenFormattingMinutes_Format_ReturnsCorrectString()
		{
			Assert.AreEqual("1", String.Format(new TimeSpanFormatProvider(), "{0:m}", TimeSpan.FromMinutes(1)));
		}

		[Test]
		public void WhenFormattingSeconds_Format_ReturnsCorrectString()
		{
			Assert.AreEqual("1", String.Format(new TimeSpanFormatProvider(), "{0:s}", TimeSpan.FromSeconds(1)));
		}

		[Test]
		public void WhenFormattingCompositeValue_Format_ReturnCorrectString()
		{
			Assert.AreEqual(
				"01:02:03:04", 
				String.Format(new TimeSpanFormatProvider(), "{0:dd:hh:mm:ss}", new TimeSpan(1, 2, 3, 4)));
		}
	}
}
