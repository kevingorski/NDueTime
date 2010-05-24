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
		public void TenAM_ParseRelativeTime_ReturnsTenAMToday()
		{
			Assert.AreEqual(DateTime.Today.AddHours(10), RelativeDateTime.Parse("10 AM"));
		}

		[Test]
		public void ThreePM_ParseRelativeTime_ReturnsThreePMToday()
		{
			Assert.AreEqual(DateTime.Today.AddHours(15), RelativeDateTime.Parse("3 PM"));
		}

		[Test]
		public void Tuesday_ParseRelativeTime_ReturnsFirstTuesdayAfterToday()
		{
			DateTime comparisonDate = DateTime.Today.AddDays(1);

			while (comparisonDate.DayOfWeek != DayOfWeek.Tuesday)
				comparisonDate = comparisonDate.AddDays(1);

			Assert.AreEqual(comparisonDate, RelativeDateTime.Parse("Tuesday"));
		}

		[Test]
		public void NextTuesday_ParseRelativeTime_ReturnsNextTuesday()
		{
			DateTime comparisonDate = DateTime.Today.AddDays(7);

			while (comparisonDate.DayOfWeek != DayOfWeek.Tuesday)
				comparisonDate = comparisonDate.AddDays(1);

			Assert.AreEqual(comparisonDate, RelativeDateTime.Parse("Next Tuesday"));
		}

		[Test]
		public void LastTuesday_ParseRelativeTime_ReturnsLastTuesday()
		{
			DateTime comparisonDate = DateTime.Today.AddDays(-7);

			while (comparisonDate.DayOfWeek != DayOfWeek.Tuesday)
				comparisonDate = comparisonDate.AddDays(-1);

			Assert.AreEqual(comparisonDate, RelativeDateTime.Parse("Last Tuesday"));
		}

		[Test]
		public void NextTuesdayAtThreePM_ParseRelativeTime_ReturnsNextTuesdayAtThreePM()
		{
			DateTime comparisonDate = DateTime.Today.AddDays(7).AddHours(15);

			while (comparisonDate.DayOfWeek != DayOfWeek.Tuesday)
				comparisonDate = comparisonDate.AddDays(1);

			Assert.AreEqual(comparisonDate, RelativeDateTime.Parse("Next Tuesday at 3 PM"));
		}

		[Test]
		public void ThreePMNextTuesday_ParseRelativeTime_ReturnsThreePMNextTuesday()
		{
			DateTime comparisonDate = DateTime.Today.AddDays(7).AddHours(15);

			while (comparisonDate.DayOfWeek != DayOfWeek.Tuesday)
				comparisonDate = comparisonDate.AddDays(1);

			Assert.AreEqual(comparisonDate, RelativeDateTime.Parse("3 PM Next Tuesday"));
		}
	}
}
