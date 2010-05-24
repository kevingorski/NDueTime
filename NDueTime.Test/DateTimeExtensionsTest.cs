using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace NDueTime.Test
{
	[TestFixture]
	public class DateTimeExtensionsTest
	{
		private DateTime _fourMinutesAgo;
		private DateTime _fiveMinutesAgo;
		private DateTime _sixMinutesAgo;

		[SetUp]
		public void SetUp()
		{
			_fourMinutesAgo = DateTime.Now.AddMinutes(-4);
			_fiveMinutesAgo = DateTime.Now.AddMinutes(-5);
			_sixMinutesAgo = DateTime.Now.AddMinutes(-6);
		}

		[Test]
		public void FiveMinutesAgo_IsBetween_FourAndSixMinutesAgo()
		{
			Assert.That(_fiveMinutesAgo.IsBetween(_fourMinutesAgo, _sixMinutesAgo));
		}

		[Test]
		public void FiveMinutesAgo_IsBetween_SixAndFourMinutesAgo()
		{
			Assert.That(_fiveMinutesAgo.IsBetween(_sixMinutesAgo, _fourMinutesAgo));
		}

		[Test]
		public void FiveMinutesAgo_ToRelativeTimeString_ReturnsFiveMinutesAgo()
		{
			Assert.AreEqual("5 minutes ago", _fiveMinutesAgo.ToRelativeTimeString());
		}

		[Test]
		public void TwoHoursFromNow_ToRelativeTimeString_ReturnsTwoHoursFromNow()
		{
			Assert.AreEqual("2 hours from now", DateTime.Now.AddHours(2).ToRelativeTimeString());
		}

		[Test]
		public void Now_ToRelativeTimeString_ReturnsAFewMomentsAgo()
		{
			Assert.AreEqual("A few moments ago", DateTime.Now.ToRelativeTimeString());
		}
	}
}