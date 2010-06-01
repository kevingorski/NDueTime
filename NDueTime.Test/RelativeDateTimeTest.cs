using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace NDueTime.Test
{
	[TestFixture]
	public class RelativeDateTimeTest
	{
		[Test]
		public void Now_ParseRelativeTime_ReturnsNow()
		{
			Assert.That((DateTime.Now - RelativeDateTime.Parse("Now")).Duration().TotalSeconds < 1);
		}

		[Test]
		public void Today_ParseRelativeTime_ReturnsToday()
		{
			Assert.AreEqual(DateTime.Today, RelativeDateTime.Parse("Today"));
		}

		[Test]
		public void Tomorrow_ParseRelativeTime_ReturnsTomorrow()
		{
			Assert.AreEqual(DateTime.Today.AddDays(1), RelativeDateTime.Parse("Tomorrow"));
		}

		[Test]
		public void TenAm_ParseRelativeTime_ReturnsTenAmToday()
		{
			Assert.AreEqual(DateTime.Today.AddHours(10), RelativeDateTime.Parse("10 AM"));
		}

		[Test]
		public void ThreePm_ParseRelativeTime_ReturnsThreePmToday()
		{
			Assert.AreEqual(DateTime.Today.AddHours(15), RelativeDateTime.Parse("3 PM"));
		}

		[Test]
		public void Tuesday_ParseRelativeTime_ReturnsTuesdayInTheSameWeek()
		{
			DateTime comparisonDate = DateTime.Today.FindDayInTheSameWeek(DayOfWeek.Tuesday);

			Assert.AreEqual(comparisonDate, RelativeDateTime.Parse("Tuesday"));
		}

		[Test]
		public void NextTuesday_ParseRelativeTime_ReturnsNextTuesday()
		{
			DateTime comparisonDate = 
				DateTime.Today
					.AddDays(7)
					.FindDayInTheSameWeek(DayOfWeek.Tuesday);

			Assert.AreEqual(comparisonDate, RelativeDateTime.Parse("Next Tuesday"));
		}

		[Test]
		public void LastTuesday_ParseRelativeTime_ReturnsLastTuesday()
		{
			DateTime comparisonDate = 
				DateTime.Today
					.AddDays(-7)
					.FindDayInTheSameWeek(DayOfWeek.Tuesday);

			Assert.AreEqual(comparisonDate, RelativeDateTime.Parse("Last Tuesday"));
		}

		[Test]
		public void NextTuesdayAtThreePm_ParseRelativeTime_ReturnsNextTuesdayAtThreePm()
		{
			DateTime comparisonDate = 
				DateTime.Today
					.AddDays(7)
					.AddHours(15)
					.FindDayInTheSameWeek(DayOfWeek.Tuesday);

			Assert.AreEqual(comparisonDate, RelativeDateTime.Parse("Next Tuesday at 3 PM"));
		}

		[Test]
		public void ThreePmNextTuesday_ParseRelativeTime_ReturnsThreePmNextTuesday()
		{
			DateTime comparisonDate = 
				DateTime.Today
					.AddDays(7)
					.AddHours(15)
					.FindDayInTheSameWeek(DayOfWeek.Tuesday);

			Assert.AreEqual(comparisonDate, RelativeDateTime.Parse("3 PM Next Tuesday"));
		}

		[Test]
		public void Noon_ParseRelateiveTime_ReturnsNoonToday()
		{
			Assert.AreEqual(DateTime.Today.AddHours(12), RelativeDateTime.Parse("Noon"));
		}

		[Test]
		public void HalfPastNoon_ParseRelativeTime_ReturnsTwelveThirtyToday()
		{
			Assert.AreEqual(DateTime.Today.AddHours(12).AddMinutes(30), RelativeDateTime.Parse("Half past noon"));
		}

		[Test]
		public void QuarterUntil3Pm_ParseRelativeTime_ReturnsTwoFortyFiveToday()
		{
			Assert.AreEqual(DateTime.Today.AddHours(14).AddMinutes(45), RelativeDateTime.Parse("Quarter until 3PM"));
		}

		[Test]
		[ExpectedException(typeof(FormatException))]
		public void InvalidInput_ParseRelativeTime_ThrowsFormatException()
		{
			RelativeDateTime.Parse("asdf");
		}
	}
}
