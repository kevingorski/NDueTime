using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace NDueTime.Test
{
	[TestFixture]
	public class DateRangeTest
	{
		private const int TestYear = 2000;
		private const int TestMonth = 1;
		private readonly DateTime _inRange = new DateTime(TestYear, TestMonth, 1, 1, 0, 0);
		private readonly DateTime _outOfRange = new DateTime(TestYear, TestMonth, 1, 4, 0, 0);
		private readonly DateRange _targetDateRange = new DateRange(
			new DateTime(TestYear, TestMonth, 1, 0, 0, 0),
			new DateTime(TestYear, TestMonth, 1, 2, 0, 0));
		private readonly DateRange _containedDateRange = new DateRange(
			new DateTime(TestYear, TestMonth, 1, 1, 0, 0),
			new DateTime(TestYear, TestMonth, 1, 2, 0, 0));
		private readonly DateRange _overlappingDateRange = new DateRange(
			new DateTime(TestYear, TestMonth, 1, 1, 0, 0),
			new DateTime(TestYear, TestMonth, 2, 0, 0, 0));
		private readonly DateRange _unrelatedDateRange = new DateRange(
			new DateTime(TestYear, TestMonth, 2, 1, 0, 0),
			new DateTime(TestYear, TestMonth, 2, 2, 0, 0));

		[Test]
		public void WhenDateIsInRange_Contains_ReturnsTrue()
		{
			Assert.That(_targetDateRange.Contains(_inRange));
		}

		[Test]
		public void WhenDateIsOutOfRange_Contains_ReturnsFalse()
		{
			Assert.IsFalse(_targetDateRange.Contains(_outOfRange));
		}

		[Test]
		public void WhenRangeIsContained_Contains_ReturnsTrue()
		{
			Assert.That(_targetDateRange.Contains(_containedDateRange));
		}

		[Test]
		public void WhenRangeIsNotContained_Contains_ReturnsFalse()
		{
			Assert.IsFalse(_targetDateRange.Contains(_unrelatedDateRange));
		}

		[Test]
		public void WhenRangeOverlaps_Overlaps_ReturnsTrue()
		{
			Assert.That(_targetDateRange.Overlaps(_overlappingDateRange));
		}

		[Test]
		public void WhenRangeDoesNotOverlap_Overlaps_ReturnsFalse()
		{
			Assert.IsFalse(_targetDateRange.Overlaps(_unrelatedDateRange));
		}
	}
}
